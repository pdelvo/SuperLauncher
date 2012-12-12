using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;

namespace web.Api
{
    public class CategoryController : ApiController
    {
        //
        // GET: /Api/{version}/Category
        public CategoryModelCollection Get(int? id = null)
        {
            using (var database = new DatabaseEntities())
            {
                var result = database.Categories
                    .Where(c => c.Parent == null && id == null || c.Parent.Value == id.Value).ToArray ()
                    .Select(m => new CategoryModel
                                     {
                                         Name = m.Name,
                                         Parent = m.Parent == null ? null : Url.Route("API Routes", new { controller = "Category", id = m.Parent }),
                                         Featured =  m.FeaturedItem == null ? null : Url.Route("API Routes", new { controller = "CategoryItem", id = m.FeaturedItem }),
                                         Items = Url.Route("API Routes", new { controller = "CategoryItem", categoryId = m.Id }),
                                         Children = Url.Route("API Routes", new{ controller = "Category", id = m.Id})
                                     }).ToList ();
                return new CategoryModelCollection(result);
            }
        }
    }
}
