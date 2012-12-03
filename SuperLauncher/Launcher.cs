using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SuperLauncher
{
    public partial class Launcher : Form
    {
        public Session Session { get; set; }
        private bool UpdateVersion { get; set; }

        public Launcher()
        {
            CheckStructure();
            InitializeComponent();
            // Set up browsers
            newsWebBrowser.Navigate("http://mcupdate.tumblr.com");
            mapsWebBrowser.Navigate("http://www.slreposervice.com/maps");
            mapsWebBrowser.Navigating += repoWebBrowser_Navigating;
            UpdateVersion = false;
            // Populate username/password
            var login = Minecraft.GetLastLogin();
            if (login != null)
            {
                usernameTextBox.Text = login.Username;
                passwordTextBox.Text = login.Password;
                rememberPasswordCheckBox.Checked = true;
            }
            WebClient client = new WebClient();
            client.OpenReadCompleted += client_OpenReadCompleted;
            client.OpenReadAsync(new Uri("http://status.mojang.com/check"));
            GetJars();
        }

        void repoWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Scheme == "http" && e.Url.Host != "www.slreposervice.com")
            {
                Process.Start(e.Url.ToString());
                e.Cancel = true;
            }
            else if (e.Url.Scheme == "install")
            {
                
            }
        }

        private class MinecraftJar
        {
            public MinecraftJar(string file)
            {
                FileName = file;
            }

            public string FileName { get; set; }

            public override string ToString()
            {
                return Path.GetFileNameWithoutExtension(FileName);
            }
        }

        private void GetJars()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => GetJars()));
                return;
            }
            if (!Directory.Exists(Path.Combine(Minecraft.DotMinecraft, "bin")))
                DoInitialUpdate();
            else
            {
                var jars = Directory.GetFiles(Path.Combine(Minecraft.DotMinecraft, "bin"), "minecraft*.jar")
                    .OrderByDescending(f => File.GetCreationTime(f));
                if (jars.Count() == 0)
                {
                    DoInitialUpdate();
                    return;
                }
                jarSelectorDropDown.Items.Clear();
                foreach (var item in jars)
                    jarSelectorDropDown.Items.Add(new MinecraftJar(item));
                jarSelectorDropDown.SelectedIndex = 0;
            }
        }

        private void DoInitialUpdate()
        {
            logInButton.Visible = false;
            downloadingProgressBar.Visible = true;
            downloadingLabel.Visible = true;
            new Thread(DownloadMinecraft).Start();
        }

        private void CheckStructure()
        {
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "bin", "natives"));
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "resources"));
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "saves"));
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "texturepacks"));
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "stats"));
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "mods"));
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "server"));
            Directory.CreateDirectory(Path.Combine(Minecraft.DotMinecraft, "repository"));
        }

        private void DownloadMinecraft()
        {
            var downloads = Minecraft.GetDownloadLinks();
            WebClient client = new WebClient();
            SetProgressBoundsAsync(0, downloads.Count);
            UpdateProgressAsync(0);
            foreach (var fileDownload in downloads)
            {
                var directory = Path.GetDirectoryName(Path.Combine(Minecraft.DotMinecraft, fileDownload.Destination));
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                client.DownloadFile(fileDownload.DownloadUri.ToString(),
                                    Path.Combine(Minecraft.DotMinecraft, fileDownload.Destination));
                UpdateProgressAsync(downloadingProgressBar.Value + 1);
            }
            Minecraft.ExpandNatives();
            UpdateVersion = true;
            FinishUpdateAsync();
        }

        private void SetProgressBoundsAsync(int min, int max)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => SetProgressBoundsAsync(min, max)));
            else
            {
                downloadingProgressBar.Minimum = min;
                downloadingProgressBar.Maximum = max;
            }
        }

        private void UpdateProgressAsync(int value)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => UpdateProgressAsync(value)));
            else
                downloadingProgressBar.Value = value;
        }

        private void FinishUpdateAsync()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => FinishUpdateAsync()));
            else
            {
                downloadingProgressBar.Visible = false;
                downloadingLabel.Visible = false;
                logInButton.Visible = true;
                GetJars();
            }
        }

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SetServiceStatusAsync("Unable to fetch status.", Color.Red);
                return;
            }
            var reader = new StreamReader(e.Result);
            var result = reader.ReadToEnd();
            var json = JArray.Parse(result);
            bool website, login, session, account, auth, skins;
            website = login = session = account = auth = skins = false;
            foreach (JObject item in json)
            {
                foreach (var subitem in item)
                {
                    if (subitem.Key == "minecraft.net") website = subitem.Value.Value<string>() == "green";
                    if (subitem.Key == "login.minecraft.net") login = subitem.Value.Value<string>() == "green";
                    if (subitem.Key == "session.minecraft.net") session = subitem.Value.Value<string>() == "green";
                    if (subitem.Key == "account.mojang.com") account = subitem.Value.Value<string>() == "green";
                    if (subitem.Key == "auth.mojang.com") auth = subitem.Value.Value<string>() == "green";
                    if (subitem.Key == "skins.minecraft.net") skins = subitem.Value.Value<string>() == "green";
                }
            }
            if (website && login && session && account && auth && skins)
                SetServiceStatusAsync("All services online.", Color.Green);
            else
            {
                string status = "Some services offline: ";
                if (website) status += "Website, ";
                if (login) status += "Login, ";
                if (session) status += "Session, ";
                if (account) status += "Account, ";
                if (auth) status += "Auth, ";
                if (skins) status += "Skins, ";
                SetServiceStatusAsync(status.Remove(status.Length - 2), Color.Red);
            }
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            logInButton.Enabled = usernameTextBox.Enabled = passwordTextBox.Enabled = false;
            logInButton.Text = "Logging in...";
            new Thread(() =>
                {
                    Session = Minecraft.DoLogin(usernameTextBox.Text, passwordTextBox.Text);
                    LoginFinishedAsync();
                }).Start();
        }

        private void LoginFinishedAsync()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => LoginFinishedAsync()));
            else
            {
                if (Session == null)
                {
                    loginFailedLabel.Visible = true;
                    loginFailedLabel.Text = "Login failed.";
                    usernameTextBox.Enabled = passwordTextBox.Enabled = logInButton.Enabled = true;
                    logInButton.Text = "Log In";
                    return;
                }
                if (!string.IsNullOrEmpty(Session.Error))
                {
                    loginFailedLabel.Visible = true;
                    loginFailedLabel.Text = Session.Error;
                    usernameTextBox.Enabled = passwordTextBox.Enabled = logInButton.Enabled = true;
                    logInButton.Text = "Log In";
                    return;
                }
                if (rememberPasswordCheckBox.Checked)
                {
                    Minecraft.SetLastLogin(new LastLogin()
                    {
                        Username = usernameTextBox.Text,
                        Password = passwordTextBox.Text
                    });
                }
                if (Directory.GetDirectories(Path.Combine(Minecraft.DotMinecraft, "saves")).Length == 0)
                {
                    var result = MessageBox.Show("You look like a new user. Would you like to play a tutorial?",
                        "Tutorial", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // TODO
                        return;
                    }
                }
                if (UpdateVersion)
                {
                    using (Stream stream = File.Open(Path.Combine(Minecraft.DotMinecraft, "bin", "version"), FileMode.Create))
                    {
                        stream.Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)Session.Version.Length)), 0, 2);
                        stream.Write(Encoding.UTF8.GetBytes(Session.Version), 0, Encoding.UTF8.GetByteCount(Session.Version));
                    }
                }
                var jar = jarSelectorDropDown.SelectedItem as MinecraftJar;
                Minecraft.RemoveSignatures(jar.FileName);
                Minecraft.LaunchMinecraft(Session, Path.GetFileName(jar.FileName));
                Close();
            }
        }

        private void SetServiceStatusAsync(string status, Color color)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => SetServiceStatusAsync(status, color)));
            else
            {
                serviceStatusLabel.ForeColor = color;
                serviceStatusLabel.Text = status;
                if (color == Color.Green)
                    statusIcon.Image = global::SuperLauncher.Properties.Resources.green;
            }
        }
    }
}
