using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SuperLauncher.Packages
{
    public static class Repository
    {
        public static PackageInstall GetPackageInstall(int id)
        {
            var client = new WebClient();
            var stream = client.OpenRead("http://www.slreposervice.com/details/" + id);
            var text = new StreamReader(stream);
            var serializer = new JsonSerializer();
            var package = serializer.Deserialize<PackageInstall>(new JsonTextReader(text));
            stream.Close();
            return package;
        }
    }
}
