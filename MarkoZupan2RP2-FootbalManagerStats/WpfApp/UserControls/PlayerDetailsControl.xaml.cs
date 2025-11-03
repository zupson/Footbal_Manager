using ClassLibrary.Models;
using ClassLibrary.Utilities;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
                new PropertyMetadata(null, OnPlayerChanged));

        //public static readonly DependencyProperty TeamStatisticsProperty =
        //     DependencyProperty.Register(
        //        nameof(TeamStatistics),
        //        typeof(TeamStatistics),
        //        typeof(PlayerDetailsControl),
        //        new PropertyMetadata(null));

        public PlayerDetailsControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Player Player
        {
            get => (Player)GetValue(PlayerProperty);
            set => SetValue(PlayerProperty, value);
        }
        //public TeamStatistics TeamStatistics
        //{
        //    get => (TeamStatistics)GetValue(TeamStatisticsProperty);
        //    set => SetValue(TeamStatisticsProperty, value);
        //}

        private static void OnPlayerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PlayerDetailsControl control && e.NewValue is Player newPlayer)
                control.SetPlayerData(newPlayer);
        }
        public void SetPlayerData(Player player)
        {
            string imageFileName = $"{player.Name}_{player.ShirtNumber}.png";
            string filePath = FileUtility.GetFilePath(imageFileName, "Images");

            if (File.Exists(filePath))//ako postoji ucitaj
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(filePath, UriKind.Absolute);
                bitmapImage.DecodePixelWidth = 70;
                bitmapImage.DecodePixelHeight = 120;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                imgPlayerProfile.Source = bitmapImage;
            }
            else
            {
                string defaultImagePath = FileUtility.GetFilePath("NoImage.png", "Images");

                if (File.Exists(defaultImagePath))
                {
                    var defaultImage = new BitmapImage();
                    defaultImage.BeginInit();
                    defaultImage.UriSource = new Uri(defaultImagePath, UriKind.Absolute);
                    defaultImage.DecodePixelWidth = 70;
                    defaultImage.DecodePixelHeight = 120;
                    defaultImage.CacheOption = BitmapCacheOption.OnLoad;
                    defaultImage.EndInit();
                    defaultImage.Freeze();

                    imgPlayerProfile.Source = defaultImage;
                }

            }
        }

        //public void setAditionalPlayerData(Player player)
        //{
        //    if (player == null) return;

        //    //propertiji koji su isiti bindaju se automastki
        //    //jer sam naveo u knstrukoru "DataContext = this;"

        //    if (TeamStatistics != null&& TeamStatistics.)
        //    {

        //    }

        //}
    }
}
