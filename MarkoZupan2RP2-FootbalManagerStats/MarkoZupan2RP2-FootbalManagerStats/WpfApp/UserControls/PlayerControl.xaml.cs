using ClassLibrary.Models;
using System.Windows;

namespace WpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : System.Windows.Controls.UserControl
    {
        //public string ShirtNumber
        //{
        //    get => (string)GetValue(ShirtNumberProperty);
        //    set => SetValue(ShirtNumberProperty, value);
        //}

        //public static readonly DependencyProperty ShirtNumberProperty =
        //    DependencyProperty.Register(
        //    nameof(ShirtNumber),
        //    typeof(string),
        //    typeof(PlayerControl),
        //    new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PlayerProperty =
            DependencyProperty.Register(
                nameof(Player),
                typeof(Player),
                typeof(PlayerControl), new PropertyMetadata(null));

        public Player Player 
        {
            get => (Player)GetValue(PlayerProperty);
            set=>SetValue(PlayerProperty, value);
        }


        public PlayerControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //private void PlayerControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    PlayerDetailsControl playerDetailsControl = new PlayerDetailsControl();
            

        //    //throw new NotImplementedException();

        //    //MessageBox.Show($"sender: {sender.ToString()}, e source: {e.Source.ToString()}");
        //}
    }
}
