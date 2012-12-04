using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Foolproof;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Configuration;

namespace web.Shared
{
    public class UsernameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var username = value as string;
            if (username == null) return false;
            return Membership.GetUser(username) == null;
        }
    }
}