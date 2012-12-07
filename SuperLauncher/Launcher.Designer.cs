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
            this.logInButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.statusIcon = new System.Windows.Forms.PictureBox();
            this.serviceStatusLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loginFailedLabel = new System.Windows.Forms.Label();
            this.homeWebBrowser = new System.Windows.Forms.WebBrowser();
            this.jarSelectionList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logInButton
            // 
            this.logInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logInButton.ForeColor = System.Drawing.Color.Black;
            this.logInButton.Location = new System.Drawing.Point(753, 8);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(75, 23);
            this.logInButton.TabIndex = 2;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(597, 10);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(150, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.Location = new System.Drawing.Point(441, 10);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(150, 20);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // statusIcon
            // 
            this.statusIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusIcon.BackColor = System.Drawing.Color.Transparent;
            this.statusIcon.Image = ((System.Drawing.Image)(resources.GetObject("statusIcon.Image")));
            this.statusIcon.Location = new System.Drawing.Point(3, 9);
            this.statusIcon.Name = "statusIcon";
            this.statusIcon.Size = new System.Drawing.Size(16, 16);
            this.statusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.statusIcon.TabIndex = 7;
            this.statusIcon.TabStop = false;
            // 
            // serviceStatusLabel
            // 
            this.serviceStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serviceStatusLabel.AutoSize = true;
            this.serviceStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.serviceStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceStatusLabel.Location = new System.Drawing.Point(17, 7);
            this.serviceStatusLabel.Name = "serviceStatusLabel";
            this.serviceStatusLabel.Size = new System.Drawing.Size(148, 20);
            this.serviceStatusLabel.TabIndex = 6;
            this.serviceStatusLabel.Text = "Checking services...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImage = global::SuperLauncher.Properties.Resources.ice;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.jarSelectionList);
            this.panel1.Controls.Add(this.loginFailedLabel);
            this.panel1.Controls.Add(this.usernameTextBox);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.statusIcon);
            this.panel1.Controls.Add(this.logInButton);
            this.panel1.Controls.Add(this.serviceStatusLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 36);
            this.panel1.TabIndex = 8;
            // 
            // loginFailedLabel
            // 
            this.loginFailedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loginFailedLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginFailedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginFailedLabel.ForeColor = System.Drawing.Color.Red;
            this.loginFailedLabel.Location = new System.Drawing.Point(318, 9);
            this.loginFailedLabel.Name = "loginFailedLabel";
            this.loginFailedLabel.Size = new System.Drawing.Size(123, 20);
            this.loginFailedLabel.TabIndex = 9;
            this.loginFailedLabel.Text = "Login Failed";
            this.loginFailedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loginFailedLabel.Visible = false;
            // 
            // homeWebBrowser
            // 
            this.homeWebBrowser.AllowNavigation = false;
            this.homeWebBrowser.AllowWebBrowserDrop = false;
            this.homeWebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.homeWebBrowser.Location = new System.Drawing.Point(0, 52);
            this.homeWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.homeWebBrowser.Name = "homeWebBrowser";
            this.homeWebBrowser.ScriptErrorsSuppressed = true;
            this.homeWebBrowser.Size = new System.Drawing.Size(856, 417);
            this.homeWebBrowser.TabIndex = 9;
            this.homeWebBrowser.Url = new System.Uri("http://mcupdate.tumblr.com", System.UriKind.Absolute);
            this.homeWebBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // jarSelectionList
            // 
            this.jarSelectionList.DropDownHeight = 100;
            this.jarSelectionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jarSelectionList.DropDownWidth = 150;
            this.jarSelectionList.FormattingEnabled = true;
            this.jarSelectionList.IntegralHeight = false;
            this.jarSelectionList.Location = new System.Drawing.Point(827, 9);
            this.jarSelectionList.Name = "jarSelectionList";
            this.jarSelectionList.Size = new System.Drawing.Size(16, 21);
            this.jarSelectionList.TabIndex = 10;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SuperLauncher.Properties.Resources.darkstone;
            this.ClientSize = new System.Drawing.Size(856, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.homeWebBrowser);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.Text = "Minecraft";
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label serviceStatusLabel;
        private System.Windows.Forms.PictureBox statusIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label loginFailedLabel;
        private System.Windows.Forms.WebBrowser homeWebBrowser;
        private System.Windows.Forms.ComboBox jarSelectionList;
    }
}

