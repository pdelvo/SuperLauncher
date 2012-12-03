using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperLauncher.Packages
{
    public class PackageInstall
    {
        public Package PrimaryItem { get; set; }
        public List<Package> Items { get; set; }
        public List<Download> Downloads { get; set; }
    }
}
