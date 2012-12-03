namespace SuperLauncher.Packages
{
    public class Package
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public string DescriptionHtml { get; set; }
        public string DescriptionMd { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string DetailedUrl { get; set; }
        public string FriendlyVersion { get; set; }
        public long Version { get; set; }
    }
}
