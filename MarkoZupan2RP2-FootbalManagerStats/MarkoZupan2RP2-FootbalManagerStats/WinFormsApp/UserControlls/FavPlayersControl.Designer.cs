namespace WinFormsApp
{
    partial class FavPlayersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpAllPlayers = new FlowLayoutPanel();
            flpFavoritePlayers = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // flpAllPlayers
            // 
            flpAllPlayers.AutoScroll = true;
            flpAllPlayers.BackColor = Color.White;
            flpAllPlayers.FlowDirection = FlowDirection.TopDown;
            flpAllPlayers.Location = new Point(14, 35);
            flpAllPlayers.Name = "flpAllPlayers";
            flpAllPlayers.Size = new Size(372, 550);
            flpAllPlayers.TabIndex = 0;
            flpAllPlayers.WrapContents = false;
            // 
            // flpFavoritePlayers
            // 
            flpFavoritePlayers.BackColor = Color.White;
            flpFavoritePlayers.FlowDirection = FlowDirection.TopDown;
            flpFavoritePlayers.Location = new Point(444, 35);
            flpFavoritePlayers.Name = "flpFavoritePlayers";
            flpFavoritePlayers.Size = new Size(350, 550);
            flpFavoritePlayers.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(14, 4);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 2;
            label1.Text = "Igrači";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(444, 4);
            label2.Name = "label2";
            label2.Size = new Size(151, 28);
            label2.TabIndex = 3;
            label2.Text = "Omiljeni igrači";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(224, 224, 224);
            btnSave.Location = new Point(14, 591);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(770, 39);
            btnSave.TabIndex = 4;
            btnSave.Text = "Spremi ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_ClickAsync;
            // 
            // FavPlayersControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flpFavoritePlayers);
            Controls.Add(flpAllPlayers);
            Name = "FavPlayersControl";
            Size = new Size(806, 645);
            Load += FavPlayersControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpAllPlayers;
        private FlowLayoutPanel flpFavoritePlayers;
        private Label label1;
        private Label label2;
        private Button btnSave;
    }
}
