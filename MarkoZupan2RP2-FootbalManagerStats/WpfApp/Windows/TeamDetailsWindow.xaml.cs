using ClassLibrary.Models;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for TeamDetailsWindow.xaml
    /// </summary>
    public partial class TeamDetailsWindow : Window
    {
        public TeamDetailsWindow(TeamStatistics teamStats, Team team)
        {
            InitializeComponent();

            tbOffsides.Text = teamStats.Offsides.ToString();
            tbFifaCode.Text = team.FifaCode.ToString();
            tbAttemptsOnGoal.Text = teamStats.AttemptsOnGoal.ToString();
            tbRedCards.Text = teamStats.RedCards.ToString();
            tbYellowCards.Text = teamStats.YellowCards.ToString();
            tbCorners.Text = teamStats.Corners.ToString();
            tbPenalties.Text = team.Penalties.ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut },
            };
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
        }
    }
}
