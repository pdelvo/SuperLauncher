using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace web.Shared
{
    public class EmailBlacklistAttribute : ValidationAttribute
    {
        static EmailBlacklistAttribute()
        {
            EmailBlackList = new List<Regex>();
            // Mojangsters
            EmailBlackList.Add(new Regex("@mojang\\.com", RegexOptions.Compiled | RegexOptions.IgnoreCase));
        }

        private static List<Regex> EmailBlackList { get; set; }

        public override bool IsValid(object value)
        {
            var email = value as string;
            foreach (var regex in EmailBlackList)
            {
                if (regex.IsMatch(email))
                    return false;
            }
            return true;
        }
    }
}

