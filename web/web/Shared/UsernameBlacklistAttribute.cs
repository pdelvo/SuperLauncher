using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace web.Shared
{
    public class UsernameBlacklistAttribute : ValidationAttribute
    {
        static UsernameBlacklistAttribute()
        {
            UsernameBlackList = new List<Regex>();
            // Mojangsters
            UsernameBlackList.Add(new Regex("notch", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("jeb", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("dinnerbone", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("mollstam", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("kappische", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("jnkboy", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("junkboy", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("jahkob", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("carlmanneh", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("danfrisk", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("bomuboi", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("lydiawinters", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("lydia", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("carnalizer", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("xlson", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("jonkagstrom", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("krisjelbring", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("Marc_IRL", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("MarcIRL", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("evilseph", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("_grum", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("eldrone", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            UsernameBlackList.Add(new Regex("C418", RegexOptions.Compiled | RegexOptions.IgnoreCase));
        }

        private static List<Regex> UsernameBlackList { get; set; }

        public override bool IsValid(object value)
        {
            var username = value as string;
            foreach (var regex in UsernameBlackList)
            {
                if (regex.IsMatch(username))
                    return false;
            }
            return true;
        }
    }
}

