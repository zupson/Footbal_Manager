using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;

namespace WinFormsApp
{
    public partial class InitSettingsControl : UserControl
    {
        private static InitialSettingsRepository _initSettingsRepo;
        private InitialSetting _initSettings;
        public event EventHandler? UserControlSubmited;

        public InitSettingsControl()
        {
            InitializeComponent();
            _initSettingsRepo = new InitialSettingsRepository();
            _initSettings = new InitialSetting();
        }

        private async void InitialSettings_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                _initSettings = await _initSettingsRepo.LoadFromFile(LocalPaths.InitialSettingsFile);
                SetRadioButtonsInSavedState(_initSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aplikacija nemoze nastaviti sa radom, nedostaje file",
                    $"{ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRadioButtonsInSavedState(InitialSetting initSettings)
        {
            foreach (var rb in gbTeam.Controls.OfType<RadioButton>())
            {
                if (rb.Tag?.ToString() == initSettings.SelectedGender.ToString())
                    rb.Checked = true;
            }
            foreach (var rb in gbLanguage.Controls.OfType<RadioButton>())
            {
                if (rb.Tag?.ToString() == initSettings.SelectedLanguage.ToString())
                    rb.Checked = true;
            }
        }

        private async void btnSaveInitialSettings_ClickAsync(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "Jeste li sigurni da želite spremiti postavke?",
                "Potvrda spremanja",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
                return; 
            
            try
            {
                var team = gbTeam.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                var language = gbLanguage.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                if (team == null || language == null)
                {
                    MessageBox.Show("Odaberite tim i jezik.", "Upozorenje");
                    return;
                }

                _initSettings = GetCheckedRbValues(team, language);

                SetRadioButtonsInSavedState(_initSettings);

                await _initSettingsRepo.SaveToFile(_initSettings, LocalPaths.InitialSettingsFile);

                UserControlSubmited?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private InitialSetting GetCheckedRbValues(RadioButton? team, RadioButton? language)
        {
            var chosenTeam = team.Tag.ToString() == Gender.Female.ToString() ? Gender.Female : Gender.Male;
            var chosenLanguage = language.Tag.ToString() == Languages.English.ToString() ? Languages.English : Languages.Croatian;

            return new InitialSetting { SelectedGender = chosenTeam, SelectedLanguage = chosenLanguage };
        }
    }
}
