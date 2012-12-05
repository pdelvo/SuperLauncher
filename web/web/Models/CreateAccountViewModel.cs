using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Foolproof;
using web.Shared;

namespace web.Models
{
    public class CreateAccountViewModel
    {
        public CreateAccountViewModel()
        {
            CapchaError = "";
        }

        [Required]
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}$", ErrorMessage = "Please enter a valid email address.")]
        [EmailValidation(ErrorMessage = "This email address is not available.")]
        [EmailBlacklist(ErrorMessage = "This is a reserved email address. If you feel you have a claim to it, please send an email to sir@cmpwn.com.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[A-Za-z0-9]*", ErrorMessage = "Letters and numbers, with no spaces.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Must be between 3-30 characters.")]
        [UsernameValidation(ErrorMessage = "This username is not available.")]
        [UsernameBlacklist(ErrorMessage = "This is a reserved name. If you feel you have a claim to it, please send an email to sir@cmpwn.com.")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [EqualTo("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string CapchaError { get; set; }
    }
}