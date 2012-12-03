using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class DownloadCollection
    {
        public DownloadCollection()
        {
            Items = new List<ItemViewModel>();
            Downloads = new List<Download>();
        }

        public ItemViewModel PrimaryItem { get; set; }
        public List<ItemViewModel> Items { get; set; }
        public List<Download> Downloads { get; set; }
    }
}