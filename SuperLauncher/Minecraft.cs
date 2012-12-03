using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Net;
using System.Diagnostics;
using System.Xml.Linq;
using SevenZip.Compression.LZMA;
using ICSharpCode.SharpZipLib.Zip;
using System.Runtime.InteropServices;

namespace SuperLauncher
{
    public static class Minecraft
    {
        private const string LoginUrl = "https://login.minecraft.net?user={0}&password={1}&version=13";
        private const string ResourceUrl = "http://s3.amazonaws.com/MinecraftResources/";
        private const string DownloadUrl = "http://s3.amazonaws.com/MinecraftDownload/";

        public static Session DoLogin(string Username, string Password)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(string.Format(LoginUrl,
                Uri.EscapeUriString(Username),
                Uri.EscapeUriString(Password)));
            var response = request.GetResponse();
            StreamReader responseStream = new StreamReader(response.GetResponseStream());
            string login = responseStream.ReadToEnd();
            responseStream.Close();
            if (login.Count(c => c == ':') != 4)
                return new Session(login.Trim());
            string[] parts = login.Split(':');
            return new Session(parts[2], parts[3], parts[0]);
        }

        public static void RemoveSignatures(string jar)
        {
            // Ensures the specified package has no signatures to speak of.
            using (var zip = new ZipFile(jar))
            {
                zip.BeginUpdate();
                var entry = zip.GetEntry("META-INF/MANIFEST.MF");
                if (entry != null)
                    zip.Delete(entry);
                zip.GetEntry("META-INF/MOJANG_C.SF");
                if (entry != null)
                    zip.Delete(entry);
                zip.GetEntry("META-INF/MOJANG_C.DSA");
                if (entry != null)
                    zip.Delete(entry);
                zip.CommitUpdate();
            }
        }

        public static string GetJavaPath()
        {
            RuntimeInfo.GatherInfo();
            if (RuntimeInfo.IsWindows)
            {
                if (File.Exists("C:\\Program Files\\Java\\jre7\\bin\\java.exe"))
                    return "C:\\Program Files\\Java\\jre7\\bin\\java.exe";
                else
                    return "C:\\Program Files (x86)\\Java\\jre7\\bin\\java.exe";
            }
            else
            {
                if (File.Exists("/usr/bin/java"))
                    return "/usr/bin/java";
                else
                    return "/bin/java";
            }
        }

        public static void LaunchMinecraft(Session session, string jar = "minecraft.jar", string server = null, params string[] mods)
        {
            var modString = "";
            foreach (var mod in mods)
                modString += mod + ";";
            ProcessStartInfo psi = new ProcessStartInfo(GetJavaPath(),
                "-Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"" + modString + jar + ";lwjgl.jar;lwjgl_util.jar" +
                "\" net.minecraft.client.Minecraft " +
                session.Username + " " + session.SessionID + (server == null ? "" : " " + server));
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                ".minecraft/bin");
            var process = Process.Start(psi);
        }

        public static void LaunchMinecraftDemo()
        {
            ProcessStartInfo psi = new ProcessStartInfo(GetJavaPath(),
                "-Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar;lwjgl.jar;lwjgl_util.jar\" net.minecraft.client.Minecraft Player - -demo");
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                ".minecraft/bin");
            Process.Start(psi);
        }

        public static List<FileDownload> GetDownloadLinks()
        {
            List<FileDownload> files = new List<FileDownload>();
            files.AddRange(new FileDownload[]
                {
                    new FileDownload(new Uri(DownloadUrl + "lwjgl.jar"), "bin/lwjgl.jar"),
                    new FileDownload(new Uri(DownloadUrl + "jinput.jar"), "bin/jinput.jar"),
                    new FileDownload(new Uri(DownloadUrl + "lwjgl_util.jar"), "bin/lwjgl_util.jar"),
                    new FileDownload(new Uri(DownloadUrl + "minecraft.jar"), "bin/minecraft.jar"),
                    new FileDownload(new Uri("https://s3.amazonaws.com/MinecraftDownload/launcher/minecraft_server.jar"), "server/minecraft_server.jar")
                });
            string natives = GetNativeArchiveFile();
            files.Add(new FileDownload(new Uri(DownloadUrl + natives), "bin/" + natives));
            return files;
        }

        public static string LastLoginFile
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft/lastlogin");
            }
        }

        public static string DotMinecraft
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");
            }
        }

        private static readonly byte[] LastLoginSalt = new byte[] { 0x0c, 0x9d, 0x4a, 0xe4, 0x1e, 0x83, 0x15, 0xfc };
        private const string LastLoginPassword = "passwordfile";
        public static LastLogin GetLastLogin()
        {
            try
            {
                byte[] encryptedLogin = File.ReadAllBytes(LastLoginFile);
                PKCSKeyGenerator crypto = new PKCSKeyGenerator(LastLoginPassword, LastLoginSalt, 5, 1);
                ICryptoTransform cryptoTransform = crypto.Decryptor;
                byte[] decrypted = cryptoTransform.TransformFinalBlock(encryptedLogin, 0, encryptedLogin.Length);
                short userLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(decrypted, 0));
                byte[] user = decrypted.Skip(2).Take(userLength).ToArray();
                short passLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(decrypted, userLength + 2));
                byte[] password = decrypted.Skip(4 + userLength).ToArray();
                LastLogin result = new LastLogin();
                result.Username = System.Text.Encoding.UTF8.GetString(user);
                result.Password = System.Text.Encoding.UTF8.GetString(password);
                return result;
            }
            catch
            {
                return null;
            }
        }

        private static string GetNativeArchiveFile()
        {
            RuntimeInfo.GatherInfo();
            string natives = "";
            if (RuntimeInfo.IsWindows)
                natives = "windows";
            else if (RuntimeInfo.IsLinux)
                natives = "linux";
            else if (RuntimeInfo.IsMacOSX)
                natives = "macosx";
            else if (RuntimeInfo.IsSolaris)
                natives = "solaris";
            natives += "_natives.jar.lzma";
            return natives;
        }

        public static void ExpandNatives()
        {
            Decoder decoder = new Decoder();
            MemoryStream output = new MemoryStream();
            using (Stream input = File.Open(Path.Combine(DotMinecraft, "bin/" + GetNativeArchiveFile()), FileMode.Open))
            {
                Decoder coder = new Decoder();

                byte[] properties = new byte[5];
                input.Read(properties, 0, 5);

                // Read in the decompress file size.
                byte[] fileLengthBytes = new byte[8];
                input.Read(fileLengthBytes, 0, 8);
                long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                coder.SetDecoderProperties(properties);
                coder.Code(input, output, input.Length, fileLength, null);
            }
            output.Seek(0, SeekOrigin.Begin);
            FastZip fastZip = new FastZip();
            fastZip.ExtractZip(output, Path.Combine(DotMinecraft, "bin/natives"), FastZip.Overwrite.Always, null, "", "", false, false);
            File.Delete(Path.Combine(DotMinecraft, "bin/" + GetNativeArchiveFile()));
        }

        public static void SetLastLogin(LastLogin login)
        {
            byte[] decrypted = BitConverter.GetBytes(IPAddress.NetworkToHostOrder((short)login.Username.Length))
                .Concat(System.Text.Encoding.UTF8.GetBytes(login.Username))
                .Concat(BitConverter.GetBytes(IPAddress.NetworkToHostOrder((short)login.Password.Length)))
                .Concat(System.Text.Encoding.UTF8.GetBytes(login.Password)).ToArray();

            PKCSKeyGenerator crypto = new PKCSKeyGenerator(LastLoginPassword, LastLoginSalt, 5, 1);
            ICryptoTransform cryptoTransform = crypto.Encryptor;
            byte[] encrypted = cryptoTransform.TransformFinalBlock(decrypted, 0, decrypted.Length);
            if (File.Exists(LastLoginFile))
                File.Delete(LastLoginFile);
            using (Stream stream = File.Create(LastLoginFile))
                stream.Write(encrypted, 0, encrypted.Length);
        }
    }

    public class LastLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Session
    {
        public Session(string Error)
        {
            this.Error = Error;
        }

        public Session(string Username, string SessionID)
        {
            this.Username = Username;
            this.SessionID = SessionID;
        }

        public Session(string Username, string SessionID, string Version)
            : this(Username, SessionID)
        {
            this.Version = Version;
        }

        public string Username { get; set; }
        public string SessionID { get; set; }
        public string Version { get; set; }
        public string Error { get; set; }
    }

    public class FileDownload
    {
        public FileDownload()
        {
        }

        public FileDownload(Uri DownloadUri, string Destination)
        {
            this.DownloadUri = DownloadUri;
            this.Destination = Destination;
        }

        public Uri DownloadUri { get; set; }
        public string Destination { get; set; }
        public int Size { get; set; }
    }
}
