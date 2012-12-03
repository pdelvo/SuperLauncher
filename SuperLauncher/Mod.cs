using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperLauncher
{
    public class Mod
    {
        public string Hash { get; set; }
        public string MinecraftHash { get; set; }
        public string JarFile { get; set; }
        public List<string> DependencyHashes { get; set; }
    }
}
