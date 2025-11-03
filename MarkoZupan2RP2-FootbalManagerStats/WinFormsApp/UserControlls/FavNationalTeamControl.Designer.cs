namespace WinFormsApp
{
    partial class FavNationalTeamControl
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
            cbNationalTeams = new ComboBox();
            lbTitleNationalTeam = new Label();
            lbNationalTeamChoose = new Label();
            btnSaveNationalTeam = new Button();
            SuspendLayout();
            // 
            // cbNationalTeams
            // 
            cbNationalTeams.FormattingEnabled = true;
            cbNationalTeams.Location = new Point(123, 91);
            cbNationalTeams.Name = "cbNationalTeams";
            cbNationalTeams.Size = new Size(141, 28);
            cbNationalTeams.TabIndex = 0;
            // 
            // lbTitleNationalTeam
            // 
            lbTitleNationalTeam.AutoSize = true;
            lbTitleNationalTeam.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTitleNationalTeam.Location = new Point(21, 27);
            lbTitleNationalTeam.Name = "lbTitleNationalTeam";
            lbTitleNationalTeam.Size = new Size(243, 28);
            lbTitleNationalTeam.TabIndex = 1;
            lbTitleNationalTeam.Text = "Omiljena reprezentacija:";
            // 
            // lbNationalTeamChoose
            // 
            lbNationalTeamChoose.AutoSize = true;
            lbNationalTeamChoose.Location = new Point(37, 94);
            lbNationalTeamChoose.Name = "lbNationalTeamChoose";
            lbNationalTeamChoose.Size = new Size(66, 20);
            lbNationalTeamChoose.TabIndex = 2;
            lbNationalTeamChoose.Text = "Odaberi:";
            // 
            // btnSaveNationalTeam
            // 
            btnSaveNationalTeam.Location = new Point(37, 146);
            btnSaveNationalTeam.Name = "btnSaveNationalTeam";
            btnSaveNationalTeam.Size = new Size(227, 36);
            btnSaveNationalTeam.TabIndex = 3;
            btnSaveNationalTeam.Text = "Spremi";
            btnSaveNationalTeam.UseVisualStyleBackColor = true;
            btnSaveNationalTeam.Click += btnSaveSelectedTeam_ClickAsync;
            // 
            // FavNationalTeamControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSaveNationalTeam);
            Controls.Add(lbNationalTeamChoose);
            Controls.Add(lbTitleNationalTeam);
            Controls.Add(cbNationalTeams);
            Name = "FavNationalTeamControl";
            Size = new Size(310, 200);
            Load += FavTeams_LoadAsync;
            VisibleChanged += FavTeams_LoadAsync;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbNationalTeams;
        private Label lbTitleNationalTeam;
        private Label lbNationalTeamChoose;
        private Button btnSaveNationalTeam;
    }
}
