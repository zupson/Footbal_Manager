using AutoMapper;
using ClassLibrary.AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;
using Microsoft.Extensions.Logging;

namespace WinFormsApp
{
    public partial class BaseForm : Form
    {
        private static InitialSettingsRepository _initSettingsRepo;
        private static TeamRepository _teamRepo;
        private static IMapper _mapper;

        private InitSettingsControl initSettControl;
        private FavNationalTeamControl favNationalTeamControl;
        private FavPlayersControl favPlyaersControl;
        private PlayerControl plyaerControl;
        private InitialSetting _initSettings;

        public BaseForm()
        {
            InitializeComponent();
            InitializeUserControls();
            InitializeRepos();
            SubscribeToEvents();
        }

        private void InitializeRepos()
        {
            _initSettingsRepo = new InitialSettingsRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MatchMappingProfile>();
                cfg.AddProfile<PlayerMappingProfile>();
                cfg.AddProfile<TeamStatisticsMappingProfile>();
            }, new LoggerFactory());
            _mapper = new Mapper(config);
            _teamRepo = new TeamRepository(new HttpClient(), _mapper);
            _initSettings = new InitialSetting();
        }

        private void SubscribeToEvents()
        {
            initSettControl.UserControlSubmited += InitialSettingsBtnSave_Click;
            favNationalTeamControl.UserControlSubmited += FavNationalTeamBtnSave_ClickAsync;
            this.Load += FormLoadAsync;
            this.MainMenuStrip = menuStrip;
        }

        private void InitializeUserControls()
        {
            initSettControl = new InitSettingsControl();
            favNationalTeamControl = new FavNationalTeamControl();
            favPlyaersControl = new FavPlayersControl();
            plyaerControl = new PlayerControl();
        }

        private void SetInitialSettings_ClickAsync(object sender, EventArgs e)
        {
            menuStrip.Visible = true;
            this.Controls.Clear();
            SetCenterPsoition(initSettControl);
            this.Controls.Add(menuStrip);
            this.Controls.Add(initSettControl);
        }

        private void InitialSettingsBtnSave_Click(object? sender, EventArgs e)
        {
            menuStrip.Visible = true;
            this.Controls.Clear();
            SetCenterPsoition(favNationalTeamControl);

            this.Controls.Add(favNationalTeamControl);
            this.Controls.Add(menuStrip);
        }

        private async void FavNationalTeamBtnSave_ClickAsync(object sender, EventArgs e)
        {
            this.Controls.Clear();
            SetCenterPsoition(favPlyaersControl);
            this.Controls.Add(favPlyaersControl);
        }

        private async void FormLoadAsync(object sender, EventArgs e)
        {

            this.Controls.Clear();

            InitialSetting initialSetting = await _initSettingsRepo.LoadFromFile(LocalPaths.InitialSettingsFile);
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(baseDir, LocalPaths.ParentFolder, LocalPaths.InitalSettingsDir, LocalPaths.InitialSettingsFile);

            if (!File.Exists(fullPath) || initialSetting == null)
            {
                this.Controls.Clear();
                menuStrip.Visible = false;

                SetCenterPsoition(initSettControl);
                this.Controls.Add(menuStrip);
                this.Controls.Add(initSettControl);
            }
            else
            {
                this.Controls.Clear();
                menuStrip.Visible = true;

                //SetCenterPsoition(favNationalTeamControl);
                SetCenterPsoition(favPlyaersControl);//poastavi da se igraci loadaju na load forme a ne na btn save u fav timovima
                this.Controls.Add(menuStrip);
                //this.Controls.Add(favNationalTeamControl);
                this.Controls.Add(favPlyaersControl);
            }
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
            "Jesi siguran da želiš zatvoriti aplikaciju?",
            "Potvrda zatvaranja",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                e.Cancel = true; 
        }

        private void SetCenterPsoition<T>(T userControl) where T : Control //ovo ekstarktati u utilitiy
        {
            int sizeX = (this.ClientSize.Width - userControl.Width) / 2;
            int sizeY = (this.ClientSize.Height - userControl.Height) / 2;
            userControl.Location = new Point(sizeX, sizeY);
        }

    }
}
