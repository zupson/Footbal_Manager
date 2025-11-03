using AutoMapper;
using ClassLibrary.AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dal;
using ClassLibrary.Models;
using ClassLibrary.Utilities;
using Microsoft.Extensions.Logging;

namespace WinFormsApp
{
    public partial class PlayerControl : UserControl
    {
        private const string croatianYes = "Da";
        private const string croatianNo = "Ne";
        private const string ImageExtensions = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
        public Player Player { get; set; }
        private bool isSelected;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private static PlayerRepository _playerRepo;
        public static IMapper _mapper;

        public bool IsSelected
        {
            get => isSelected; set
            {
                isSelected = value;
                this.BackColor = value ? Color.White : SystemColors.ControlDark;
            }
        }

        public PlayerControl()
        {
            InitializeComponent();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MatchMappingProfile>();
                cfg.AddProfile<PlayerMappingProfile>();
                cfg.AddProfile<TeamStatisticsMappingProfile>();
            }, new LoggerFactory());
            _mapper = new Mapper(config);

            _playerRepo = new PlayerRepository(new HttpClient(), _mapper);
            this.Load += PlayerControl_Load;
        }

        public void SetPlayerData(Player player)
        {
            Player = player;
            lbFullName.Text = player.Name;
            lbShirtNumber.Text = player.ShirtNumber.ToString();
            lbPosition.Text = player.Position;
            lbIsCaptain.Text = player.IsCaptain.Equals(true) ? croatianYes : croatianNo;
            lbIsFavorite.Text = player.IsFavourite.Equals(true) ? croatianYes : croatianNo;

            if (!string.IsNullOrEmpty(player.ImagePath))
            {
                string imageFileName = $"{player.Name}_{player.ShirtNumber}.png";

                string filePath = FileUtility.GetFilePath(imageFileName, "Images");

                if (File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(stream);
                        Image resized = new Bitmap(img, new Size(70, 120));
                        pbPlayerProfilePicture.Image?.Dispose();
                        pbPlayerProfilePicture.Image = resized;
                        img.Dispose();
                    }
                }
            }
        }

        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsSelected = true;
                var selectedControls = ((FlowLayoutPanel)this.Parent).Controls
                               .OfType<PlayerControl>()
                               .Where(pc => pc.IsSelected)
                               .Select(pc => pc.Player)
                               .ToList();

                if (!selectedControls.Any())
                    selectedControls.Add(((PlayerControl)sender).Player);

                this.DoDragDrop(selectedControls, DragDropEffects.Move);
            }
            if (e.Button == MouseButtons.Right) { IsSelected = false; }
        }
        //
        public void SaveImage(Image image, Player player)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imgDir = Path.Combine(baseDir, LocalPaths.ParentFolder, LocalPaths.PlayersDir, LocalPaths.ImagesDir);

            if (!Directory.Exists(imgDir))
                Directory.CreateDirectory(imgDir);

            string imageFileName = $"{player.Name}_{player.ShirtNumber}.png";

            string filePath = FileUtility.GetFilePath(imageFileName, "Images");

            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private async void btnSetPicture_ClickAsync(object sender, EventArgs e)
        {
            openFileDialog.Filter = ImageExtensions;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                SaveImage(img, Player);
                Player.ImagePath = $"{Player.Name}_{Player.ShirtNumber}.png";

                Image resized = new Bitmap(img, new Size(70, 120));
                pbPlayerProfilePicture.Image = resized;
                img.Dispose();//nije nam potreba slika u punoj veleicini
            }
        }

        private void PlayerControl_Load(object sender, EventArgs e)
        {
            if (Player != null)
                SetPlayerData(Player);
        }

        private void RemovePicture_MouseClick(object sender, MouseEventArgs e)
        {
            pbPlayerProfilePicture.Image.Dispose();
            string filePath = FileUtility.GetFilePath("Images/NoImage.png");

            if (File.Exists(filePath))
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    Image defaultImage = Image.FromStream(stream);
                    Image resized = new Bitmap(defaultImage, new Size(70, 120));
                    pbPlayerProfilePicture.Image = resized;
                    defaultImage.Dispose();
                }
            else
                pbPlayerProfilePicture.Image = null;

            Player.ImagePath = null;
        }
    }
}
