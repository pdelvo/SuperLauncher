using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Foolproof;
using System.ComponentModel.DataAnnotations;

namespace web.Shared
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var email = value as string;
            if (email == null) return false;
            return Membership.GetUserNameByEmail(email) == null;
        }
    }
}