using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using web.Service.Model;

namespace web.Shared
{
    public class ContentNameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var name = value as string;
            var user = Membership.GetUser();
            if (user == null)
                return false;
            bool valid;
            using (var database = new DatabaseEntities())
            {
                var matches = from i in database.Items
                              where i.User == user.UserName && 
                                  i.Name.ToUpper() == name.ToUpper()
                              select i;
                valid = !matches.Any();
            }
            return valid;
        }
    }
}