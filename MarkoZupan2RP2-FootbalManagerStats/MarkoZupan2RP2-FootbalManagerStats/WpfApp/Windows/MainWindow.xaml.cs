using AutoMapper;
using ClassLibrary.AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static InitialSettingsRepository _initSettingsRepo;
        private static TeamRepository _teamRepo;
        private static MatchRepository _matchRepo;
        private static IMapper _mapper;

        //varijable za filtirranje matchova
        private InitialSetting initialSetting;//RADI

        private Team _selectedFavTeam;
        private Team _selectedRivalTeam;
        private List<Match> _allMatches;
        private Match _finalMatch;

        private TeamStatistics favTeamStatistics;
        private TeamStatistics rivalTeamStatistics;

        public MainWindow()
        {
            this.Loaded += Window_Loaded;
            InitializeComponent();

            _initSettingsRepo = new InitialSettingsRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MatchMappingProfile>();
                cfg.AddProfile<PlayerMappingProfile>();
                cfg.AddProfile<TeamMappingProfile>();
                cfg.AddProfile<TeamStatisticsMappingProfile>();
            }, new LoggerFactory());

            _mapper = new Mapper(config);
            _teamRepo = new TeamRepository(new HttpClient(), _mapper);
            _matchRepo = new MatchRepository(new HttpClient(), _mapper);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                initialSetting = await _initSettingsRepo.LoadFromFile(LocalPaths.InitialSettingsFile);//dovlacimo gender, size
                SetFormWindowSize(initialSetting.SelectedScreenSize);//setiramo size windowa

                await InitFavTeamComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task InitFavTeamComboBox()
        {
            var loadedFavTeamFromFile = await TeamServices.Instance.Load(initialSetting.SelectedGender);//SAMO FIFA CODE I COUNTRY

            var allFavTeams = await TeamServices.Instance.GetTeams(initialSetting.SelectedGender);
            cbSavedFavTeam.Items.Clear();
            allFavTeams.ForEach(t => cbSavedFavTeam.Items.Add(t));
            cbSavedFavTeam.SelectedItem = loadedFavTeamFromFile;
        }

        private void SetFormWindowSize(ScreenSize screenSize)
        {
            switch (screenSize)
            {
                case ScreenSize.Fullscreen:
                    this.WindowState = WindowState.Maximized;
                    break;
                case ScreenSize.Resolution_1024x768:
                    this.Width = 1024;
                    this.Height = 768;
                    break;
                case ScreenSize.Resolution_1280x1024:
                    this.Width = 1280;
                    this.Height = 1024;
                    break;
                case ScreenSize.Resolution_1920x1080:
                    this.Width = 1920;
                    this.Height = 1080;
                    break;
                default:
                    this.SizeToContent = SizeToContent.WidthAndHeight;
                    break;
            }

            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen; ovo se nemoze koristii jer je je velicina prozora varijabilna i ovisi sto korisnik odabere-onda se samo oze racunati rucno
            this.Left = (SystemParameters.WorkArea.Width - this.Width) / 2 + SystemParameters.WorkArea.Left;
            this.Top = (SystemParameters.WorkArea.Height - this.Height) / 2 + SystemParameters.WorkArea.Top;
        }

        private async void cbFavTeam_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedFavTeam = (Team)cbSavedFavTeam.SelectedItem;//country i fifa code samo, zato moramo getall sa SelectedMatch repoa

            if (_selectedFavTeam == null || initialSetting == null) return;

            await TeamServices.Instance.Save(_selectedFavTeam, initialSetting.SelectedGender);

            _allMatches = await _matchRepo.GetAllFromApi(initialSetting.SelectedGender, _selectedFavTeam.FifaCode);

            var allRivalTeams = await TeamServices.Instance.GetRivalTeams(initialSetting.SelectedGender, _selectedFavTeam);
            cbRivalTeam.Items.Clear();
            allRivalTeams.ForEach(rt => cbRivalTeam.Items.Add(rt));

            TryFindMatch();
        }

        private void TryFindMatch()
        {
            if (_selectedFavTeam == null || _allMatches == null || _selectedRivalTeam == null) return;

            var matchesWithFavCode = _allMatches.FindAll(match =>
               match.HomeTeam.FifaCode == _selectedFavTeam.FifaCode ||
               match.AwayTeam.FifaCode == _selectedFavTeam.FifaCode);

            if (!matchesWithFavCode.Any()) return;

            _finalMatch = matchesWithFavCode.FirstOrDefault(m =>
                m.HomeTeam.FifaCode == _selectedRivalTeam.FifaCode ||
                m.AwayTeam.FifaCode == _selectedRivalTeam.FifaCode);

            if (_finalMatch == null)
            {
                lbSavedFavTeamResult.Content = "-";
                lbRivalTeamResult.Content = "-";
                return;
            }

            SetGoalsForEachTeam();
        }

        private void SetGoalsForEachTeam()
        {
            int HomeTeamGoals = _finalMatch.HomeTeam.Goals;
            int HomeTeamPenalties = _finalMatch.HomeTeam.Penalties;

            int AwayTeamGoals = _finalMatch.AwayTeam.Goals;
            int AwayTeamPenalties = _finalMatch.AwayTeam.Penalties;

            if (_finalMatch.HomeTeam.FifaCode == _selectedFavTeam.FifaCode)
            {
                favTeamStatistics = _finalMatch.HomeTeamStatistics;
                rivalTeamStatistics = _finalMatch.AwayTeamStatistics;
                lbSavedFavTeamResult.Content = HomeTeamGoals + HomeTeamPenalties;
                lbRivalTeamResult.Content = AwayTeamGoals + AwayTeamPenalties;
            }
            else
            {
                favTeamStatistics = _finalMatch.AwayTeamStatistics;
                rivalTeamStatistics = _finalMatch.HomeTeamStatistics;
                lbSavedFavTeamResult.Content = AwayTeamGoals + AwayTeamPenalties;
                lbRivalTeamResult.Content = HomeTeamGoals + HomeTeamPenalties;
            }
        }

        private void cbRivalTeam_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedRivalTeam = (Team)cbRivalTeam.SelectedItem;
            TryFindMatch();
        }

        private void btnSavedFavTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRivalTeam == null)
            {
                MessageBox.Show("Za početak trebate odabrati protivnicki tim.");
                return;
            }

            favTeamStatistics = _finalMatch.HomeTeam.FifaCode == _selectedFavTeam.FifaCode
               ? _finalMatch.HomeTeamStatistics
               : _finalMatch.AwayTeamStatistics;

            var teamDetailsWindow = new TeamDetailsWindow(favTeamStatistics, _selectedFavTeam);
            teamDetailsWindow.Owner = this;
            teamDetailsWindow.ShowDialog();
        }

        
        private void btnRivalTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRivalTeam == null)
            {
                MessageBox.Show("Za početak trebate odabrati protivnicki tim.");
                return;
            }

            rivalTeamStatistics = _finalMatch.HomeTeam.FifaCode == _selectedRivalTeam.FifaCode
                ? _finalMatch.HomeTeamStatistics
                : _finalMatch.AwayTeamStatistics;

            var teamDetailsWindow = new TeamDetailsWindow(rivalTeamStatistics, _selectedRivalTeam);
            teamDetailsWindow.Owner = this;
            teamDetailsWindow.ShowDialog();
        }
        private void btnShowStartingLineUpOfTeams_Click(object sender, RoutedEventArgs e)
        {

            if (favTeamStatistics == null || rivalTeamStatistics == null)
            {
                MessageBox.Show("Nedostaju podaci o obje ekipe.");
                return;
            }



            var playerWindow = new StartingElevenWindow();
            playerWindow.SetFavTeamPlayers(favTeamStatistics.StartingEleven);
            playerWindow.SetRivalTeamPlayers(rivalTeamStatistics.StartingEleven);
            playerWindow.Owner = this;
            playerWindow.ShowDialog();

        }

        private void OpenInitialSettingsWindow_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new InitialSettingsWindow();
            settingsWindow.ShowDialog();
            this.Close();
        }
    }
}