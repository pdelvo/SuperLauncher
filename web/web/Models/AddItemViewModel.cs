using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web.Shared;

namespace web.Models
{
    public class AddItemViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The maximum length is 100 characters.")]
        [ContentNameValidation(ErrorMessage = "You already have an item by that name. To update, edit the item directly.")]
        public string Name { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "The maximum length is 1000 characters.")]
        public string Description { get; set; }
        public string Type { get; set; }
    }
}