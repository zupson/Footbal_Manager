using AutoMapper;
using ClassLibrary.AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;
using Microsoft.Extensions.Logging;

namespace WinFormsApp
{
    public partial class FavPlayersControl : UserControl
    {
        private static InitialSettingsRepository _initSettRepo;
        private static TeamRepository _teamRepo;
        private static PlayerRepository _playerRepo;
        private static IMapper _mapper;
        private static PlayerControl _playerControl;

        private const int MaxFavoritePlayers = 3;

        public FavPlayersControl()
        {
            InitializeComponent();
            _initSettRepo = new InitialSettingsRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MatchMappingProfile>();
                cfg.AddProfile<PlayerMappingProfile>();
                cfg.AddProfile<TeamStatisticsMappingProfile>();
            }, new LoggerFactory());

            _mapper = new Mapper(config);
            _teamRepo = new TeamRepository(new HttpClient(), _mapper);
            _playerRepo = new PlayerRepository(new HttpClient(), _mapper);

            InitDnD();
        }

        private void InitDnD()
        {
            flpAllPlayers.AllowDrop = true;
            flpFavoritePlayers.AllowDrop = true;

            flpAllPlayers.DragEnter += FlowLayoutPanel_DragEnter;
            flpFavoritePlayers.DragEnter += FlowLayoutPanel_DragEnter;

            flpAllPlayers.DragDrop += FlowLayoutPanel_DragDrop;
            flpFavoritePlayers.DragDrop += FlowLayoutPanel_DragDrop;
        }

        private void FlowLayoutPanel_DragDrop(object? sender, DragEventArgs e)
        {
            var targetPanel = sender as FlowLayoutPanel;

            if (!e.Data.GetDataPresent(typeof(List<Player>))) return;

            var players = e.Data.GetData(typeof(List<Player>)) as List<Player>;

            var sourcePanel = (targetPanel == flpAllPlayers)
                ? flpFavoritePlayers
                : flpAllPlayers;
            if (targetPanel == flpFavoritePlayers)
            {
                int newPlayersCount = players.Count(player => !targetPanel.Controls
                                                                .OfType<PlayerControl>()
                                                                .Any(pc => pc.Player == player));

                if (newPlayersCount == 0)
                    return;
                if (flpFavoritePlayers.Controls.Count + newPlayersCount > MaxFavoritePlayers)
                {
                    MessageBox.Show($"Maksimalno {MaxFavoritePlayers} omiljenih igrača je dozvoljeno.");
                    return;
                }
            }

            foreach (var player in players)
            {
                var playerControl = sourcePanel.Controls
                    .OfType<PlayerControl>()
                    .FirstOrDefault(pc => pc.Player == player);

                if (playerControl != null &&
                    !targetPanel.Controls.OfType<PlayerControl>().Any(pc => pc.Player == player))
                {
                    sourcePanel.Controls.Remove(playerControl);
                    targetPanel.Controls.Add(playerControl);
                }
            }
        }

        private void FlowLayoutPanel_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<Player>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        public async Task LoadPlayersAsync()
        {
            try
            {
                var initialSetting = await _initSettRepo.LoadFromFile(LocalPaths.InitialSettingsFile);
                Team favTeam;

                List<Player> players;

                var selectedGender = initialSetting.SelectedGender;

                if (selectedGender.ToString() == Gender.Female.ToString())
                {
                    favTeam = await _teamRepo.LoadFromFile(LocalPaths.FemaleFavTeamFile);
                    if (favTeam.FifaCode == null)
                    {
                        ShowFavTeamControl();
                        return;
                    }

                    players = await _playerRepo.GetAllFromApi(Gender.Female, favTeam.FifaCode);
                    await LoadAsync(LocalPaths.FemaleAllPlayersFile, LocalPaths.FemaleFavPlayersFile, selectedGender);
                }
                else
                {
                    favTeam = await _teamRepo.LoadFromFile(LocalPaths.MaleFavTeamFile);
                    if (favTeam.FifaCode == null)
                    {
                        ShowFavTeamControl();
                        return;
                    }

                    players = await _playerRepo.GetAllFromApi(Gender.Male, favTeam.FifaCode);
                    await LoadAsync(LocalPaths.MaleAllPlayersFile, LocalPaths.MaleFavPlayersFile, selectedGender);
                }
                ShowPlayers(players);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowFavTeamControl()
        {
            MessageBox.Show("Prvo moraš postaviti omiljeni tim.", "Upozorenje", MessageBoxButtons.OK);

            var favNationalTeamControl = new FavNationalTeamControl();

            favNationalTeamControl.UserControlSubmited += FavNationalTeamControl_UserControlSubmitedAsync;

            this.Controls.Clear();
            favNationalTeamControl.Left = (this.ClientSize.Width - favNationalTeamControl.Width) / 2;
            favNationalTeamControl.Top = (this.ClientSize.Height - favNationalTeamControl.Height)/2;
            this.Controls.Add(favNationalTeamControl);
        }

        private async void FavNationalTeamControl_UserControlSubmitedAsync(object? sender, EventArgs e)
        {
            this.Controls.Clear();
            await LoadPlayersAsync();
        }

        private void ShowPlayers(List<Player> allPlayers)
        {
            foreach (var player in allPlayers)
            {
                PlayerControl playerControl = new PlayerControl();
                playerControl.SetPlayerData(player);
                flpAllPlayers.Controls.Add(playerControl);
            }
        }

        private async Task SaveAsync(string filePathAll, string filePathFav)
        {
            var allPlayers = flpAllPlayers.Controls.OfType<PlayerControl>().Select(pc => pc.Player).ToList();
            var favPlayers = flpFavoritePlayers.Controls.OfType<PlayerControl>().Select(pc => pc.Player).ToList();

            await _playerRepo.SaveEntityListToFile(allPlayers, filePathAll);
            await _playerRepo.SaveEntityListToFile(favPlayers, filePathFav);
        }

        private async Task LoadAsync(string filePathAll, string filePathFav, Gender selectedGender)
        {
            var allPlayers = await _playerRepo.LoadEntityListFromFile(filePathAll, selectedGender);
            var favPlayers = await _playerRepo.LoadEntityListFromFile(filePathFav, selectedGender);

            flpAllPlayers.Controls.Clear();

            foreach (var player in allPlayers)
            {
                var playerControl = new PlayerControl();
                playerControl.SetPlayerData(player);
                flpAllPlayers.Controls.Add(playerControl);
            }

            flpFavoritePlayers.Controls.Clear();

            foreach (var player in favPlayers)
            {
                var playerControl = new PlayerControl();
                playerControl.SetPlayerData(player);
                flpFavoritePlayers.Controls.Add(playerControl);
            }
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            var initialSetting = await _initSettRepo.LoadFromFile(LocalPaths.InitialSettingsFile);
            if (initialSetting == null)
            {
                MessageBox.Show("Odaberi pocetne postavke");
                return;
            }

            if (initialSetting.SelectedGender == Gender.Female)
                await SaveAsync(LocalPaths.FemaleAllPlayersFile, LocalPaths.FemaleFavPlayersFile);
            else
                await SaveAsync(LocalPaths.MaleAllPlayersFile, LocalPaths.MaleFavPlayersFile);
        }

        private async void FavPlayersControl_Load(object sender, EventArgs e)
        {
            await LoadPlayersAsync();
        }
    }
}
