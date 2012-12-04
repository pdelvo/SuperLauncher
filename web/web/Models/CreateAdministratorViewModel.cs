using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Foolproof;

namespace web.Models
{
    public class CreateAdministratorViewModel
    {
        [Required(ErrorMessage="Required")]
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Confirm Password")]
        [EqualTo("Password", ErrorMessage="Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}