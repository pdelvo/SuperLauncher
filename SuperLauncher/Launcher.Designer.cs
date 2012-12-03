namespace SuperLauncher
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.logInGroupBox = new System.Windows.Forms.GroupBox();
            this.loginFailedLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusIcon = new System.Windows.Forms.PictureBox();
            this.serviceStatusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.newsWebBrowser = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.jarSelectorDropDown = new System.Windows.Forms.ComboBox();
            this.rememberPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadingLabel = new System.Windows.Forms.Label();
            this.downloadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.logInGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logInGroupBox
            // 
            this.logInGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logInGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.logInGroupBox.Controls.Add(this.downloadingProgressBar);
            this.logInGroupBox.Controls.Add(this.downloadingLabel);
            this.logInGroupBox.Controls.Add(this.rememberPasswordCheckBox);
            this.logInGroupBox.Controls.Add(this.jarSelectorDropDown);
            this.logInGroupBox.Controls.Add(this.loginFailedLabel);
            this.logInGroupBox.Controls.Add(this.logInButton);
            this.logInGroupBox.Controls.Add(this.passwordTextBox);
            this.logInGroupBox.Controls.Add(this.usernameTextBox);
            this.logInGroupBox.ForeColor = System.Drawing.Color.Black;
            this.logInGroupBox.Location = new System.Drawing.Point(444, 351);
            this.logInGroupBox.Name = "logInGroupBox";
            this.logInGroupBox.Size = new System.Drawing.Size(385, 126);
            this.logInGroupBox.TabIndex = 0;
            this.logInGroupBox.TabStop = false;
            this.logInGroupBox.Text = "Log In";
            // 
            // loginFailedLabel
            // 
            this.loginFailedLabel.AutoSize = true;
            this.loginFailedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginFailedLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.loginFailedLabel.Location = new System.Drawing.Point(2, 99);
            this.loginFailedLabel.Name = "loginFailedLabel";
            this.loginFailedLabel.Size = new System.Drawing.Size(89, 17);
            this.loginFailedLabel.TabIndex = 3;
            this.loginFailedLabel.Text = "Login failed: ";
            this.loginFailedLabel.Visible = false;
            // 
            // logInButton
            // 
            this.logInButton.ForeColor = System.Drawing.Color.Black;
            this.logInButton.Location = new System.Drawing.Point(303, 97);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(75, 23);
            this.logInButton.TabIndex = 2;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(6, 45);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(372, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(5, 19);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(373, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.statusIcon);
            this.panel1.Controls.Add(this.serviceStatusLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.logInGroupBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 480);
            this.panel1.TabIndex = 1;
            // 
            // statusIcon
            // 
            this.statusIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusIcon.Image = global::SuperLauncher.Properties.Resources.red;
            this.statusIcon.Location = new System.Drawing.Point(3, 460);
            this.statusIcon.Name = "statusIcon";
            this.statusIcon.Size = new System.Drawing.Size(16, 17);
            this.statusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.statusIcon.TabIndex = 7;
            this.statusIcon.TabStop = false;
            // 
            // serviceStatusLabel
            // 
            this.serviceStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serviceStatusLabel.AutoSize = true;
            this.serviceStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceStatusLabel.Location = new System.Drawing.Point(16, 458);
            this.serviceStatusLabel.Name = "serviceStatusLabel";
            this.serviceStatusLabel.Size = new System.Drawing.Size(148, 20);
            this.serviceStatusLabel.TabIndex = 6;
            this.serviceStatusLabel.Text = "Checking services...";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "SuperLauncher";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::SuperLauncher.Properties.Resources.commandBlock;
            this.pictureBox1.Location = new System.Drawing.Point(7, 370);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 342);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.newsWebBrowser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(818, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Minecraft News";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // newsWebBrowser
            // 
            this.newsWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsWebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.newsWebBrowser.Location = new System.Drawing.Point(3, 3);
            this.newsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.newsWebBrowser.Name = "newsWebBrowser";
            this.newsWebBrowser.ScriptErrorsSuppressed = true;
            this.newsWebBrowser.Size = new System.Drawing.Size(812, 310);
            this.newsWebBrowser.TabIndex = 0;
            this.newsWebBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(746, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Maps";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(746, 293);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Servers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(746, 293);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Texture Packs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(746, 293);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Mods";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(746, 293);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Settings";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(746, 293);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Skins";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // jarSelectorDropDown
            // 
            this.jarSelectorDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jarSelectorDropDown.FormattingEnabled = true;
            this.jarSelectorDropDown.Location = new System.Drawing.Point(177, 70);
            this.jarSelectorDropDown.Name = "jarSelectorDropDown";
            this.jarSelectorDropDown.Size = new System.Drawing.Size(201, 21);
            this.jarSelectorDropDown.TabIndex = 4;
            // 
            // rememberPasswordCheckBox
            // 
            this.rememberPasswordCheckBox.AutoSize = true;
            this.rememberPasswordCheckBox.Location = new System.Drawing.Point(6, 71);
            this.rememberPasswordCheckBox.Name = "rememberPasswordCheckBox";
            this.rememberPasswordCheckBox.Size = new System.Drawing.Size(126, 17);
            this.rememberPasswordCheckBox.TabIndex = 5;
            this.rememberPasswordCheckBox.Text = "Remember Password";
            this.rememberPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadingLabel
            // 
            this.downloadingLabel.AutoSize = true;
            this.downloadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadingLabel.Location = new System.Drawing.Point(6, 100);
            this.downloadingLabel.Name = "downloadingLabel";
            this.downloadingLabel.Size = new System.Drawing.Size(86, 20);
            this.downloadingLabel.TabIndex = 6;
            this.downloadingLabel.Text = "Updating...";
            this.downloadingLabel.Visible = false;
            // 
            // downloadingProgressBar
            // 
            this.downloadingProgressBar.Location = new System.Drawing.Point(177, 96);
            this.downloadingProgressBar.Name = "downloadingProgressBar";
            this.downloadingProgressBar.Size = new System.Drawing.Size(201, 23);
            this.downloadingProgressBar.TabIndex = 7;
            this.downloadingProgressBar.Visible = false;
            // 
            // Launcher
            // 
            this.AcceptButton = this.logInButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SuperLauncher.Properties.Resources.snow;
            this.ClientSize = new System.Drawing.Size(856, 504);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.Text = "Minecraft";
            this.logInGroupBox.ResumeLayout(false);
            this.logInGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox logInGroupBox;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label loginFailedLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser newsWebBrowser;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label serviceStatusLabel;
        private System.Windows.Forms.PictureBox statusIcon;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.CheckBox rememberPasswordCheckBox;
        private System.Windows.Forms.ComboBox jarSelectorDropDown;
        private System.Windows.Forms.Label downloadingLabel;
        private System.Windows.Forms.ProgressBar downloadingProgressBar;
    }
}

