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
            this.updatePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.updateProgressBar = new System.Windows.Forms.ProgressBar();
            this.logInPanel = new System.Windows.Forms.Panel();
            this.jarSelectionList = new System.Windows.Forms.ComboBox();
            this.loginFailedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.updatePanel.SuspendLayout();
            this.logInPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logInButton
            // 
            this.logInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logInButton.ForeColor = System.Drawing.Color.Black;
            this.logInButton.Location = new System.Drawing.Point(461, 3);
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
            this.passwordTextBox.Location = new System.Drawing.Point(305, 5);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(150, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.Location = new System.Drawing.Point(149, 5);
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
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.updatePanel);
            this.panel1.Controls.Add(this.logInPanel);
            this.panel1.Controls.Add(this.statusIcon);
            this.panel1.Controls.Add(this.serviceStatusLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 36);
            this.panel1.TabIndex = 8;
            // 
            // updatePanel
            // 
            this.updatePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updatePanel.BackColor = System.Drawing.Color.Transparent;
            this.updatePanel.Controls.Add(this.label1);
            this.updatePanel.Controls.Add(this.updateProgressBar);
            this.updatePanel.Location = new System.Drawing.Point(325, 1);
            this.updatePanel.Name = "updatePanel";
            this.updatePanel.Size = new System.Drawing.Size(554, 28);
            this.updatePanel.TabIndex = 10;
            this.updatePanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Installing Update...";
            // 
            // updateProgressBar
            // 
            this.updateProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateProgressBar.Location = new System.Drawing.Point(205, 2);
            this.updateProgressBar.Name = "updateProgressBar";
            this.updateProgressBar.Size = new System.Drawing.Size(341, 23);
            this.updateProgressBar.TabIndex = 0;
            // 
            // logInPanel
            // 
            this.logInPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logInPanel.BackColor = System.Drawing.Color.Transparent;
            this.logInPanel.Controls.Add(this.jarSelectionList);
            this.logInPanel.Controls.Add(this.logInButton);
            this.logInPanel.Controls.Add(this.loginFailedLabel);
            this.logInPanel.Controls.Add(this.passwordTextBox);
            this.logInPanel.Controls.Add(this.usernameTextBox);
            this.logInPanel.Location = new System.Drawing.Point(325, 1);
            this.logInPanel.Name = "logInPanel";
            this.logInPanel.Size = new System.Drawing.Size(554, 28);
            this.logInPanel.TabIndex = 10;
            // 
            // jarSelectionList
            // 
            this.jarSelectionList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jarSelectionList.DropDownHeight = 100;
            this.jarSelectionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jarSelectionList.DropDownWidth = 150;
            this.jarSelectionList.FormattingEnabled = true;
            this.jarSelectionList.IntegralHeight = false;
            this.jarSelectionList.Location = new System.Drawing.Point(535, 4);
            this.jarSelectionList.Name = "jarSelectionList";
            this.jarSelectionList.Size = new System.Drawing.Size(16, 21);
            this.jarSelectionList.TabIndex = 10;
            // 
            // loginFailedLabel
            // 
            this.loginFailedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loginFailedLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginFailedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginFailedLabel.ForeColor = System.Drawing.Color.Red;
            this.loginFailedLabel.Location = new System.Drawing.Point(3, 4);
            this.loginFailedLabel.Name = "loginFailedLabel";
            this.loginFailedLabel.Size = new System.Drawing.Size(146, 20);
            this.loginFailedLabel.TabIndex = 9;
            this.loginFailedLabel.Text = "Login Failed";
            this.loginFailedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loginFailedLabel.Visible = false;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SuperLauncher.Properties.Resources.darkstone;
            this.ClientSize = new System.Drawing.Size(884, 512);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.Text = "Minecraft";
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.updatePanel.ResumeLayout(false);
            this.updatePanel.PerformLayout();
            this.logInPanel.ResumeLayout(false);
            this.logInPanel.PerformLayout();
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
        private System.Windows.Forms.ComboBox jarSelectionList;
        private System.Windows.Forms.Panel logInPanel;
        private System.Windows.Forms.Panel updatePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar updateProgressBar;
    }
}

