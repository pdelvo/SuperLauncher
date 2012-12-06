using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;

namespace web.Models
{
    public class BlobViewModel
    {
        public BlobViewModel()
        {
        }

        public BlobViewModel(Blob blob)
        {
            DownloadUrl = blob.DownloadUrl;
            DestinationPath = blob.DestinationPath;
            Name = blob.Name;
        }

        public string Name { get; set; }
        public string DownloadUrl { get; set; }
        public string DestinationPath { get; set; }
    }
}