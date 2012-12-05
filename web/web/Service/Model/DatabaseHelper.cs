using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Service.Model
{
    public static class DatabaseHelper
    {
        public static Item ItemById(this DatabaseEntities database, int id)
        {
            return database.Items.FirstOrDefault(i => i.Id == id);
        }

        public static Category CategoryById(this DatabaseEntities database, int id)
        {
            return database.Categories.FirstOrDefault(c => c.Id == id);
        }

        public static Category CategoryByName(this DatabaseEntities database, string name)
        {
            return database.Categories.FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());
        }
    }
}