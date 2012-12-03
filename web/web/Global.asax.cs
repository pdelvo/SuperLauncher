using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using web.Service.Model;

namespace web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Categories", // Route name
                "category/{*name}", // URL with parameters
                new { controller = "Web", action = "Category" }
            );

            routes.MapRoute(
                "Item", // Route name
                "{action}/{id}", // URL with parameters
                new { controller = "Item", action = "Index" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            UpdateDatabase();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private void UpdateDatabase()
        {
            // Builds out default categories if missing
            using (var database = new DataEntities())
            {
                Category maps;
                if (!database.Categories.Any())
                {
                    maps = new Category
                    {
                        Name = "Maps"
                    };
                    database.Categories.AddObject(maps);
                    database.Categories.AddObject(new Category
                    {
                        Name = "Servers"
                    });
                    database.Categories.AddObject(new Category
                    {
                        Name = "Texture Packs"
                    });
                    database.Categories.AddObject(new Category
                    {
                        Name = "Mods"
                    });
                    database.Categories.AddObject(new Category
                    {
                        Name = "Skins"
                    });
                }
                else
                    maps = database.Categories.FirstOrDefault(c => c.Name == "Maps");
#if DEBUG
                // Add some test items
                if (!maps.Items.Any())
                {
                    maps.Items.Add(new Item
                    {
                        Name = "Team Fortress 2: 2fort",
                        Description =
                            "SethBling and Hypixel's latest multiplayer collaboration.\n\n[YouTube](http://youtu.be/NmlqBKGfQ9I)",
                        ImageUrl = "/Data/Maps/Images/testFeature.png",
                        Type = "map:multiplayer"
                    });
                    maps.Featured = maps.Items.FirstOrDefault().Id;
                }
#endif
                database.SaveChanges();
            }
        }
    }
}