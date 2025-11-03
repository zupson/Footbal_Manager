namespace WinFormsApp
{
    partial class InitSettingsControl
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
            gbTeam = new GroupBox();
            rbTeamMale = new RadioButton();
            rbTeamFemale = new RadioButton();
            gbLanguage = new GroupBox();
            rbLanguageEnglish = new RadioButton();
            rbLanguageCroatian = new RadioButton();
            lbInitialSettings = new Label();
            btnSaveInitialSettings = new Button();
            gbTeam.SuspendLayout();
            gbLanguage.SuspendLayout();
            SuspendLayout();
            // 
            // gbTeam
            // 
            gbTeam.Controls.Add(rbTeamMale);
            gbTeam.Controls.Add(rbTeamFemale);
            gbTeam.Location = new Point(46, 79);
            gbTeam.Name = "gbTeam";
            gbTeam.Size = new Size(258, 70);
            gbTeam.TabIndex = 0;
            gbTeam.TabStop = false;
            gbTeam.Text = "Ekipa";
            // 
            // rbTeamMale
            // 
            rbTeamMale.AutoSize = true;
            rbTeamMale.Location = new Point(129, 26);
            rbTeamMale.Name = "rbTeamMale";
            rbTeamMale.Size = new Size(72, 24);
            rbTeamMale.TabIndex = 1;
            rbTeamMale.Tag = "Male";
            rbTeamMale.Text = "Muška";
            rbTeamMale.UseVisualStyleBackColor = true;
            // 
            // rbTeamFemale
            // 
            rbTeamFemale.AutoSize = true;
            rbTeamFemale.Checked = true;
            rbTeamFemale.Location = new Point(6, 26);
            rbTeamFemale.Name = "rbTeamFemale";
            rbTeamFemale.Size = new Size(76, 24);
            rbTeamFemale.TabIndex = 0;
            rbTeamFemale.TabStop = true;
            rbTeamFemale.Tag = "Female";
            rbTeamFemale.Text = "Ženska";
            rbTeamFemale.UseVisualStyleBackColor = true;
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbLanguageEnglish);
            gbLanguage.Controls.Add(rbLanguageCroatian);
            gbLanguage.Location = new Point(46, 164);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Size = new Size(258, 96);
            gbLanguage.TabIndex = 1;
            gbLanguage.TabStop = false;
            gbLanguage.Text = "Jezik";
            // 
            // rbLanguageEnglish
            // 
            rbLanguageEnglish.AutoSize = true;
            rbLanguageEnglish.Location = new Point(129, 26);
            rbLanguageEnglish.Name = "rbLanguageEnglish";
            rbLanguageEnglish.Size = new Size(84, 24);
            rbLanguageEnglish.TabIndex = 3;
            rbLanguageEnglish.Tag = "English";
            rbLanguageEnglish.Text = "Engleski";
            rbLanguageEnglish.UseVisualStyleBackColor = true;
            // 
            // rbLanguageCroatian
            // 
            rbLanguageCroatian.AutoSize = true;
            rbLanguageCroatian.Checked = true;
            rbLanguageCroatian.Location = new Point(6, 26);
            rbLanguageCroatian.Name = "rbLanguageCroatian";
            rbLanguageCroatian.Size = new Size(83, 24);
            rbLanguageCroatian.TabIndex = 2;
            rbLanguageCroatian.TabStop = true;
            rbLanguageCroatian.Tag = "Croatian";
            rbLanguageCroatian.Text = "Hrvatski";
            rbLanguageCroatian.UseVisualStyleBackColor = true;
            // 
            // lbInitialSettings
            // 
            lbInitialSettings.AutoSize = true;
            lbInitialSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbInitialSettings.Location = new Point(26, 37);
            lbInitialSettings.Name = "lbInitialSettings";
            lbInitialSettings.Size = new Size(183, 28);
            lbInitialSettings.TabIndex = 2;
            lbInitialSettings.Text = "Početne postavke:";
            // 
            // btnSaveInitialSettings
            // 
            btnSaveInitialSettings.Location = new Point(46, 279);
            btnSaveInitialSettings.Name = "btnSaveInitialSettings";
            btnSaveInitialSettings.Size = new Size(258, 42);
            btnSaveInitialSettings.TabIndex = 3;
            btnSaveInitialSettings.Text = "Spremi ";
            btnSaveInitialSettings.UseVisualStyleBackColor = true;
            btnSaveInitialSettings.Click += btnSaveInitialSettings_ClickAsync;
            // 
            // InitSettingsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btnSaveInitialSettings);
            Controls.Add(lbInitialSettings);
            Controls.Add(gbLanguage);
            Controls.Add(gbTeam);
            Name = "InitSettingsControl";
            Size = new Size(350, 400);
            Load += InitialSettings_LoadAsync;
            gbTeam.ResumeLayout(false);
            gbTeam.PerformLayout();
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbTeam;
        private RadioButton rbTeamMale;
        private RadioButton rbTeamFemale;
        private GroupBox gbLanguage;
        private RadioButton rbLanguageEnglish;
        private RadioButton rbLanguageCroatian;
        private Label lbInitialSettings;
        private Button btnSaveInitialSettings;
    }
}
