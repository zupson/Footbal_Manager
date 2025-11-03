using ClassLibrary.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WpfApp.UserControls;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for StartingElevenWindow.xaml
    /// </summary>
    public partial class StartingElevenWindow : Window
    {
        private const string GoliePosition = "Goalie";
        private const string DefenderPosition = "Defender";
        private const string MidFieldPosition = "Midfield";
        private const string ForwardPosition = "Forward";


        private const string FavTeamColor = "Blue";
        private const string RivalTeamColor = "Red";

        private Popup _playerPopup;
        private PlayerDetailsControl _popupContent;

        public StartingElevenWindow()
        {
            InitializeComponent();
            _playerPopup = new Popup
            {
                Placement = PlacementMode.MousePoint,
                AllowsTransparency = true,
                StaysOpen = false,
            };
            _popupContent = new PlayerDetailsControl();
            _playerPopup.Child = _popupContent;
        }

        //  | kolona
        //  - row

        internal void SetFavTeamPlayers(List<Player> startingEleven)
        {
            startingEleven.ForEach(p => p.TeamColor = FavTeamColor);

            var positionPlayersDictionary = startingEleven
                .GroupBy(p => p.Position)
                .ToDictionary(g => g.Key, g => g.ToList());


            foreach (var playerGroup in positionPlayersDictionary)
            {
                int columnIndex = playerGroup.Key switch
                {
                    GoliePosition => 0,
                    DefenderPosition => 1,
                    MidFieldPosition => 2,
                    ForwardPosition => 3,
                };
                if (columnIndex >= 0)
                    AddPlayersToGridRow(playerGroup.Value, columnIndex);
            }
        }

        internal void SetRivalTeamPlayers(List<Player> startingEleven)
        {
            startingEleven.ForEach(p => p.TeamColor = RivalTeamColor);

            var positionPlayersDictionary = startingEleven
                .GroupBy(p => p.Position)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var playerGroup in positionPlayersDictionary)
            {
                int columnIndex = playerGroup.Key switch
                {
                    GoliePosition => 8,
                    DefenderPosition => 7,
                    MidFieldPosition => 6,
                    ForwardPosition => 5,
                };

                if (columnIndex >= 0)
                    AddPlayersToGridRow(playerGroup.Value, columnIndex);
            }
        }

        private void AddPlayersToGridRow(List<Player> players, int columnIndex)
        {
            var stack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5, 20, 5, 20)
            };

            foreach (var player in players)
            {
                var playerControl = new PlayerControl
                {
                    DataContext = player,
                    Margin = new Thickness(15, 30, 15, 30),
                };

                playerControl.MouseEnter += (s, e) =>
                {
                    var control = s as PlayerControl;
                    if (control != null)
                    {
                        _popupContent.Player = (Player)control.DataContext;//poziva OnPlayerChanged a on inetno poziva SetPlayerData 
                        _playerPopup.IsOpen = true;
                    }
                };

                playerControl.MouseLeave += (s, e) => _playerPopup.IsOpen = false;

                stack.Children.Add(playerControl);
            }

            Grid.SetColumn(stack, columnIndex);
            TeamGrid.Children.Add(stack);
        }
    }
}
