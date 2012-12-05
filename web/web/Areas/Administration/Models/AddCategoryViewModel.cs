using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Areas.Administration.Models
{
    public class AddCategoryViewModel
    {
        public int? Parent { get; set; }
        public string ParentName { get; set; }
        [Required]
        public string Name { get; set; }
    }
}