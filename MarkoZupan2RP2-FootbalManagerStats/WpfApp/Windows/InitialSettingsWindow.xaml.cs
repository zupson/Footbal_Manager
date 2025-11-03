using AutoMapper.Features;
using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for InitialSettingsWindow.xaml
    /// </summary>
    public partial class InitialSettingsWindow : Window
    {
        private static InitialSettingsRepository _initSettingsRepo;
        public InitialSettingsWindow()
        {
            InitializeComponent();
            _initSettingsRepo = new InitialSettingsRepository();
            cbGender.ItemsSource = Enum.GetValues(typeof(Gender));
            cbLanguage.ItemsSource = Enum.GetValues(typeof(Languages));
            cbResolution.ItemsSource = Enum.GetValues(typeof(ScreenSize));
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbLanguage.SelectedIndex == -1
                   || cbGender.SelectedIndex == -1
                   || cbResolution.SelectedIndex == -1)
                {
                    MessageBox.Show("Moras postaviti vrijesnoti u svakom od prikazanih izbornika.");
                    return;
                }

                var cbSelectedItemLanguage = (Languages)cbLanguage.SelectedItem;
                var cbSelectedItemGender = (Gender)cbGender.SelectedItem;
                var cbSelectedItemResolution = (ScreenSize)cbResolution.SelectedItem;
               
                InitialSetting initSett = new InitialSetting
                {
                    SelectedLanguage = cbSelectedItemLanguage,
                    SelectedGender = cbSelectedItemGender,
                    SelectedScreenSize = cbSelectedItemResolution
                };

                await _initSettingsRepo.SaveToFile(initSett, LocalPaths.InitialSettingsFile);
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Jeste li sigurin da želite odustati?",
                "Potvrda",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                cbLanguage.SelectedIndex = -1;
                cbGender.SelectedIndex = -1;
                cbResolution.SelectedIndex = -1;
            }
        }
    }
}
