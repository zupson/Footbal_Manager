using ClassLibrary.Models;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerDetailsControl.xaml
    /// </summary>
    public partial class PlayerDetailsControl : UserControl
    {
        public static readonly DependencyProperty PlayerProperty =
            DependencyProperty.Register(
                nameof(Player),
                typeof(Player),
                typeof(PlayerDetailsControl),
                new PropertyMetadata(null));

        public Player Player
        {
            get => (Player)GetValue(PlayerProperty);
            set => SetValue(PlayerProperty, value);
        }
        public PlayerDetailsControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
