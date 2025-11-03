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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
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
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // initSettToolStripMenuItem
            // 
            initSettToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setInitiSettToolStripMenuItem, promjeniToolStripMenuItem });
            initSettToolStripMenuItem.Name = "initSettToolStripMenuItem";
            resources.ApplyResources(initSettToolStripMenuItem, "initSettToolStripMenuItem");
            // 
            // setInitiSettToolStripMenuItem
            // 
            setInitiSettToolStripMenuItem.Name = "setInitiSettToolStripMenuItem";
            resources.ApplyResources(setInitiSettToolStripMenuItem, "setInitiSettToolStripMenuItem");
            setInitiSettToolStripMenuItem.Click += SetInitialSettings_ClickAsync;
            // 
            // promjeniToolStripMenuItem
            // 
            resources.ApplyResources(promjeniToolStripMenuItem, "promjeniToolStripMenuItem");
            promjeniToolStripMenuItem.Name = "promjeniToolStripMenuItem";
            // 
            // favTeamToolStripMenuItem
            // 
            favTeamToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chooseFavTimToolStripMenuItem });
            favTeamToolStripMenuItem.Name = "favTeamToolStripMenuItem";
            resources.ApplyResources(favTeamToolStripMenuItem, "favTeamToolStripMenuItem");
            // 
            // chooseFavTimToolStripMenuItem
            // 
            chooseFavTimToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chooseFavPlayersToolStripMenuItem });
            chooseFavTimToolStripMenuItem.Name = "chooseFavTimToolStripMenuItem";
            resources.ApplyResources(chooseFavTimToolStripMenuItem, "chooseFavTimToolStripMenuItem");
            // 
            // chooseFavPlayersToolStripMenuItem
            // 
            chooseFavPlayersToolStripMenuItem.Name = "chooseFavPlayersToolStripMenuItem";
            resources.ApplyResources(chooseFavPlayersToolStripMenuItem, "chooseFavPlayersToolStripMenuItem");
            chooseFavPlayersToolStripMenuItem.Click += FavNationalTeamBtnSave_ClickAsync;
            // 
            // BaseForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "BaseForm";
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