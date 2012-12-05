using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SuperLauncher.Packages;
using System.Diagnostics;

namespace SuperLauncher
{
    public partial class PackageInstaller : Form
    {
        public PackageInstall PackageInstall { get; set; }

        public PackageInstaller(int package)
        {
            InitializeComponent();
            webKitBrowser.Navigating += webKitBrowser_Navigating;
            new Thread(() => UpdatePackageAsync(Repository.GetPackageInstall(package))).Start();
        }

        void webKitBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
            if (e.Url.Scheme == "http" && e.Url.Host != "www.slreposervice.com")
                Process.Start(e.Url.ToString());
        }

        private void UpdatePackageAsync(PackageInstall package)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => UpdatePackageAsync(package)));
            else
            {
                PackageInstall = package;
                installButton.Enabled = true;
                progressBar.Style = ProgressBarStyle.Continuous;
                webKitBrowser.DocumentText = FormatHtml(package.PrimaryItem.DescriptionHtml);
                imagePictureBox.ImageLocation = "http://www.slreposervice.com" + package.PrimaryItem.ImageUrl;
                packageNameLabel.Text = "Install " + package.PrimaryItem.Name;
                packageVersionLabel.Text = "Version " + package.PrimaryItem.FriendlyVersion;
                dependencyListBox.Items.Clear();
                foreach (var item in package.Items)
                    dependencyListBox.Items.Add(item.Name);
            }
        }

        private string FormatHtml(string html)
        {
            return "<!doctype html><html><head><style>body{font-family:Helvetica;}a{color:#333;}</style></head><body>" +
                html + "</body></html>";
        }
    }
}
