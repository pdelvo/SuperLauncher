using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Foolproof;

namespace web.Shared
{
    public class EmailValidationAttribute : ModelAwareValidationAttribute
    {
        public override bool IsValid(object value, object container)
        {
            var email = value as string;
            if (email == null)
                return false;
            return Membership.GetUserNameByEmail(email) != null;
        }
    }
}