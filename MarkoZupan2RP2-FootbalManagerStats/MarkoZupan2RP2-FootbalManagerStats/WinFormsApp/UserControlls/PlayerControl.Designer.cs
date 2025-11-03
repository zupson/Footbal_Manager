namespace WinFormsApp
{
    partial class PlayerControl
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lbFullName = new Label();
            lbShirtNumber = new Label();
            lbPosition = new Label();
            label1 = new Label();
            lbIsCaptain = new Label();
            label2 = new Label();
            lbIsFavorite = new Label();
            pbPlayerProfilePicture = new PictureBox();
            btnSetPicture = new Button();
            ((System.ComponentModel.ISupportInitialize)pbPlayerProfilePicture).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 71);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 2;
            label3.Text = "Pozicija";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 39);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 3;
            label4.Text = "Broj";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 101);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 4;
            label5.Text = "Kapetan";
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.BackColor = Color.White;
            lbFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbFullName.Location = new Point(43, 10);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(0, 20);
            lbFullName.TabIndex = 5;
            // 
            // lbShirtNumber
            // 
            lbShirtNumber.AutoSize = true;
            lbShirtNumber.BackColor = Color.White;
            lbShirtNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbShirtNumber.Location = new Point(45, 39);
            lbShirtNumber.Name = "lbShirtNumber";
            lbShirtNumber.Size = new Size(0, 20);
            lbShirtNumber.TabIndex = 6;
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.BackColor = Color.White;
            lbPosition.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbPosition.Location = new Point(75, 71);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(0, 20);
            lbPosition.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime";
            // 
            // lbIsCaptain
            // 
            lbIsCaptain.AutoSize = true;
            lbIsCaptain.BackColor = Color.White;
            lbIsCaptain.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbIsCaptain.Location = new Point(75, 101);
            lbIsCaptain.Name = "lbIsCaptain";
            lbIsCaptain.Size = new Size(0, 20);
            lbIsCaptain.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 130);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 9;
            label2.Text = "Omiljen";
            // 
            // lbIsFavorite
            // 
            lbIsFavorite.AutoSize = true;
            lbIsFavorite.BackColor = Color.White;
            lbIsFavorite.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbIsFavorite.Location = new Point(70, 130);
            lbIsFavorite.Name = "lbIsFavorite";
            lbIsFavorite.Size = new Size(0, 20);
            lbIsFavorite.TabIndex = 10;
            // 
            // pbPlayerProfilePicture
            // 
            pbPlayerProfilePicture.BackColor = Color.Transparent;
            pbPlayerProfilePicture.Image = Properties.Resources.NoImage;
            pbPlayerProfilePicture.InitialImage = Properties.Resources.NoImage;
            pbPlayerProfilePicture.Location = new Point(232, 4);
            pbPlayerProfilePicture.Name = "pbPlayerProfilePicture";
            pbPlayerProfilePicture.Size = new Size(98, 120);
            pbPlayerProfilePicture.SizeMode = PictureBoxSizeMode.CenterImage;
            pbPlayerProfilePicture.TabIndex = 11;
            pbPlayerProfilePicture.TabStop = false;
            pbPlayerProfilePicture.MouseClick += RemovePicture_MouseClick;
            // 
            // btnSetPicture
            // 
            btnSetPicture.BackColor = Color.FromArgb(224, 224, 224);
            btnSetPicture.Location = new Point(232, 130);
            btnSetPicture.Name = "btnSetPicture";
            btnSetPicture.Size = new Size(98, 34);
            btnSetPicture.TabIndex = 12;
            btnSetPicture.Text = "Set picture";
            btnSetPicture.UseVisualStyleBackColor = false;
            btnSetPicture.Click += btnSetPicture_ClickAsync;
            // 
            // PlayerControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            Controls.Add(pbPlayerProfilePicture);
            Controls.Add(btnSetPicture);
            Controls.Add(lbIsFavorite);
            Controls.Add(label2);
            Controls.Add(lbIsCaptain);
            Controls.Add(lbPosition);
            Controls.Add(lbShirtNumber);
            Controls.Add(lbFullName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "PlayerControl";
            Size = new Size(345, 170);
            Load += PlayerControl_Load;
            MouseDown += PlayerControl_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pbPlayerProfilePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbFullName;
        private Label lbPosition;
        private Label lbShirtNumber;
        private Label label1;
        private Label lbIsCaptain;
        private Label label2;
        private Label lbIsFavorite;
        private PictureBox pbPlayerProfilePicture;
        private Button btnSetPicture;
    }
}
