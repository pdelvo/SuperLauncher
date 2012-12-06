using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class ReviewItemViewModel
    {
        public ItemInProgress Item { get; set; }
        public List<string> Categories { get; set; }
        [Required]
        public string Version { get; set; }
    }
}