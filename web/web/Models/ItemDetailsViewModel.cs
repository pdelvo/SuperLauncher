using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class ItemDetailsViewModel
    {
        public ItemDetailsViewModel()
        {
            Dependencies = new List<Guid>();
        }

        public string ItemName { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Guid> Dependencies { get; set; }
    }
}