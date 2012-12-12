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
                                         Parent = m.Parent == null ? null : Url.Route("Default API Route", new { controller = "Category", id = m.Parent }),
                                         Featured =  m.FeaturedItem == null ? null : Url.Route("Default API Route", new { controller = "CategoryItem", id = m.FeaturedItem }),
                                         Items = Url.Route("Default API Route", new { controller = "CategoryItem", categoryId = m.Id }),
                                         Children = Url.Route("Default API Route", new{ controller = "Category", id = m.Id})
                                     }).ToList ();
                return new CategoryModelCollection(result);
            }
        }
    }
    [DataContract(Name = "category")]
    public class CategoryModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Parent { get; set; }

        [DataMember]
        public string Featured { get; set; }

        [DataMember]
        public string Children { get; set; }

        [DataMember]
        public string Items { get; set; }
    }

    [CollectionDataContract(Name = "categories", Namespace = "")]
    public class CategoryModelCollection : Collection<CategoryModel>
    {
        public CategoryModelCollection()
        {

        }
        public CategoryModelCollection(IList<CategoryModel> updates)
            : base(updates)
        {

        }
    }
}
