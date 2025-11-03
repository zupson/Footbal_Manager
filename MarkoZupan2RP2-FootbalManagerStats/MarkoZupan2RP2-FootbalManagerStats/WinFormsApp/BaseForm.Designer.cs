namespace WinFormsApp
{
    partial class BaseForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            initSettToolStripMenuItem = new ToolStripMenuItem();
            setInitiSettToolStripMenuItem = new ToolStripMenuItem();
            promjeniToolStripMenuItem = new ToolStripMenuItem();
            favTeamToolStripMenuItem = new ToolStripMenuItem();
            chooseFavTimToolStripMenuItem = new ToolStripMenuItem();
            chooseFavPlayersToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { initSettToolStripMenuItem, favTeamToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(982, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // initSettToolStripMenuItem
            // 
            initSettToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setInitiSettToolStripMenuItem, promjeniToolStripMenuItem });
            initSettToolStripMenuItem.Name = "initSettToolStripMenuItem";
            initSettToolStripMenuItem.Size = new Size(138, 24);
            initSettToolStripMenuItem.Text = "Početne postavke";
            // 
            // setInitiSettToolStripMenuItem
            // 
            setInitiSettToolStripMenuItem.Name = "setInitiSettToolStripMenuItem";
            setInitiSettToolStripMenuItem.Size = new Size(155, 26);
            setInitiSettToolStripMenuItem.Text = "Postavi";
            setInitiSettToolStripMenuItem.Click += SetInitialSettings_ClickAsync;
            // 
            // promjeniToolStripMenuItem
            // 
            promjeniToolStripMenuItem.Enabled = false;
            promjeniToolStripMenuItem.Name = "promjeniToolStripMenuItem";
            promjeniToolStripMenuItem.Size = new Size(155, 26);
            promjeniToolStripMenuItem.Text = "Promijeni";
            // 
            // favTeamToolStripMenuItem
            // 
            favTeamToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chooseFavTimToolStripMenuItem });
            favTeamToolStripMenuItem.Name = "favTeamToolStripMenuItem";
            favTeamToolStripMenuItem.Size = new Size(105, 24);
            favTeamToolStripMenuItem.Text = "Omiljeni tim";
            // 
            // chooseFavTimToolStripMenuItem
            // 
            chooseFavTimToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chooseFavPlayersToolStripMenuItem });
            chooseFavTimToolStripMenuItem.Name = "chooseFavTimToolStripMenuItem";
            chooseFavTimToolStripMenuItem.Size = new Size(172, 26);
            chooseFavTimToolStripMenuItem.Text = "Odaberi tim";
            // 
            // chooseFavPlayersToolStripMenuItem
            // 
            chooseFavPlayersToolStripMenuItem.Name = "chooseFavPlayersToolStripMenuItem";
            chooseFavPlayersToolStripMenuItem.Size = new Size(253, 26);
            chooseFavPlayersToolStripMenuItem.Text = "Odaberi omiljene igrače";
            chooseFavPlayersToolStripMenuItem.Click += FavNationalTeamBtnSave_ClickAsync;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "BaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BaseForm";
            FormClosing += BaseForm_FormClosing;
            Load += FormLoadAsync;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem initSettToolStripMenuItem;
        private ToolStripMenuItem favTeamToolStripMenuItem;
        private ToolStripMenuItem setInitiSettToolStripMenuItem;
        private ToolStripMenuItem promjeniToolStripMenuItem;
        private ToolStripMenuItem chooseFavTimToolStripMenuItem;
        private ToolStripMenuItem chooseFavPlayersToolStripMenuItem;
    }
}