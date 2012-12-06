using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;

namespace web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BacklogController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new BacklogViewModel();
            using (var database = new DatabaseEntities())
            {
                var items = new List<Item>(
                    from i in database.Items
                    where !i.Approved
                    select i);
                viewModel.Backlog = new List<BacklogItem>();
                foreach (var item in items)
                {
                    viewModel.Backlog.Add(new BacklogItem
                    {
                        Name = item.Name,
                        Category = item.Category == null ? null : item.Category.Name,
                        Description = item.Description,
                        FriendlyVersion = item.FriendlyVersion,
                        Type = item.Type,
                        User = item.User,
                        Id = item.Id
                    });
                }
            }
            return View(viewModel);
        }
    }
}
