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
    public class DetailItemController : ApiController
    {
        //
        // GET: /Api/{version}/CategoryItem?categoryId={id}
        [ActionName("Get")]
        public DetailItemCollection GetList(int categoryId)
        {
            using (var database = new DatabaseEntities())
            {
                var category = database.CategoryById(categoryId);
                if (category == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                return new DetailItemCollection(category.Items.ToArray().Select(GetModel).ToList());
            }
            
        }

        //
        // GET: /Api/{version}/CategoryItem/{id}
        public DetailItem Get(int id)
        {
            using (var database = new DatabaseEntities())
            {
                var item = database.ItemById(id);
                if (item == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                return GetModel (item);
            }
        }

        private DetailItem GetModel(Item item)
        {
            return new DetailItem
                       {
                           Id = item.Id,
                           Category = Url.Route("API Routes", new { controller = "Category", id = item.CategoryId }),
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
}