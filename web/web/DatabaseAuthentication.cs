using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using web.Service.Model;

namespace web
{
    public static class DatabaseAuthentication
    {
        public static bool CreateUser(string username, string email, string password, bool administrator)
        {
            if (UserExists(username))
                return false;
            password = HashPassword(password);
            using (var database = new DatabaseEntities())
            {
                database.Users.Add(new User()
                {
                    Administrator = administrator,
                    Email = email,
                    Username = username,
                    PasswordHash = password
                });
                database.SaveChanges();
            }
            return true;
        }

        public static string HashPassword(string password)
        {
            var sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hashString = "";
            for (int i = 0; i < hash.Length; i++)
                hashString += hash[i].ToString("x2");
            return hashString;
        }

        internal static bool UserExists(string username)
        {
            bool exists = false;
            using (var database = new DatabaseEntities())
                exists = database.Users.Any(u => u.Username.ToUpper() == username.ToUpper());
            return exists;
        }
    }
}