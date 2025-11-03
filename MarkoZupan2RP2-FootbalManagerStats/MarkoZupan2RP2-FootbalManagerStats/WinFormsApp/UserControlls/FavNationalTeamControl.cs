using AutoMapper;
using ClassLibrary.AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;
using Microsoft.Extensions.Logging;

namespace WinFormsApp
{
    public partial class FavNationalTeamControl : UserControl
    {
        private const string fifaCode = "FifaCode";
        private const string displayName = "DisplayName";

        private static InitialSettingsRepository _initSettingsRepo;
        private static TeamRepository _teamRepo;
        private static IMapper _mapper;

        public event EventHandler? UserControlSubmited;


        public FavNationalTeamControl()
        {
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
        }

        private async void btnSaveSelectedTeam_ClickAsync(object sender, EventArgs e)
        {
            var selectedTeam = cbNationalTeams.SelectedItem as Team;
            if (selectedTeam == null)
            {
                MessageBox.Show("Molimo odaberite validan tim.");
                return;
            }

            var savedInitialSetting = await _initSettingsRepo.LoadFromFile(LocalPaths.InitialSettingsFile);
            if (savedInitialSetting.SelectedGender.ToString() == Gender.Female.ToString())
            {
                await LoadFemaleTeamsAsync(Gender.Female);
                await TeamServices.Instance.Save(selectedTeam, Gender.Female);
                //await _teamRepo.SaveToFile(selectedTeam,
                //    LocalPaths.FemaleFavTeamFile);
            }
            else
            {
                await LoadMaleTeamsAsync(Gender.Male);
                await TeamServices.Instance.Save(selectedTeam, Gender.Male);

                //await _teamRepo.SaveToFile(selectedTeam,
                //    LocalPaths.MaleFavTeamFile);
            }

            SetSelectedFavTeam(selectedTeam);

            UserControlSubmited?.Invoke(this, EventArgs.Empty);
        }

        private async void FavTeams_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                Team savedFavTeam;
                
                var savedInitialSetting = await _initSettingsRepo.LoadFromFile(LocalPaths.InitialSettingsFile);
                if (savedInitialSetting.SelectedGender == null)
                {
                    MessageBox.Show("Ponovno odaberite početne postavke.");
                    return;
                }
                if (savedInitialSetting.SelectedGender.ToString() == Gender.Female.ToString())
                {
                    await LoadFemaleTeamsAsync(Gender.Female);
                    //savedFavTeam = await _teamRepo.LoadFromFile(LocalPaths.FemaleFavTeamFile);
                    savedFavTeam = await TeamServices.Instance.Load(Gender.Female);
                }
                else
                {
                    await LoadMaleTeamsAsync(Gender.Male);
                    //savedFavTeam = await _teamRepo.LoadFromFile(LocalPaths.MaleFavTeamFile);
                    savedFavTeam = await TeamServices.Instance.Load(Gender.Male);

                }
                if (savedFavTeam.FifaCode != null)
                {
                    SetSelectedFavTeam(savedFavTeam);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void SetSelectedFavTeam(Team? savedFavTeam)
        {
            if (savedFavTeam != null)
                cbNationalTeams.SelectedValue = savedFavTeam.FifaCode;
        }

        private async Task LoadMaleTeamsAsync(Gender gender)
        {
            try
            {
                var maleNationalTeams = await _teamRepo.GetAllFromApi(gender);
                cbNationalTeams.DataSource = maleNationalTeams;
                cbNationalTeams.DisplayMember = displayName;
                cbNationalTeams.ValueMember = fifaCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private async Task LoadFemaleTeamsAsync(Gender gender)
        {
            try
            {
                var femaleNationalTeams = await _teamRepo.GetAllFromApi(gender);
                cbNationalTeams.DataSource = femaleNationalTeams;
                cbNationalTeams.DisplayMember = displayName;
                cbNationalTeams.ValueMember = fifaCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
