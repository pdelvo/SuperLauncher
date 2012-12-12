using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Http;
using web.Models;
using web.Service.Model;

namespace web.Api
{
    public class CategoryItemController : ApiController
    {
        //
        // GET: /Api/{version}/CategoryItem?categoryId={id}
        [ActionName("Get")]
        public CategoryItemCollection GetList(int categoryId)
        {
            using (var database = new DatabaseEntities())
            {
                var category = database.CategoryById(categoryId);
                if (category == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                return new CategoryItemCollection(category.Items.ToArray().Select(GetModel).ToList());
            }
            
        }

        //
        // GET: /Api/{version}/CategoryItem/{id}
        public CategoryItem Get(int id)
        {
            using (var database = new DatabaseEntities())
            {
                var item = database.ItemById(id);
                if (item == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                return GetModel (item);
            }
        }

        private CategoryItem GetModel(Item item)
        {
            return new CategoryItem
                       {
                           Id = item.Id,
                           Category = Url.Route("Default API Route", new { controller = "Category", id = item.CategoryId }),
                           User = item.User,
                           Name = item.Name,
                           Description = item.Description,
                           ImageUrl = item.ImageUrl,
                           Type = item.Type,
                           Address = item.Address,
                           Version = item.Version,
                           FriendlyVersion = item.FriendlyVersion,
                           Approved = item.Approved,
                           ProvidesUpdate = item.ProvidesUpdate
                       };
        }
    }

    [DataContract(Name = "item")]
    public class CategoryItem
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int Version { get; set; }

        [DataMember]
        public string FriendlyVersion { get; set; }

        [DataMember]
        public bool Approved { get; set; }

        [DataMember]
        public int? ProvidesUpdate { get; set; }
    }

    [CollectionDataContract(Name = "items", Namespace = "")]
    public class CategoryItemCollection : Collection<CategoryItem>
    {
        public CategoryItemCollection()
        {

        }
        public CategoryItemCollection(IList<CategoryItem> updates)
            : base(updates)
        {

        }
    }
}