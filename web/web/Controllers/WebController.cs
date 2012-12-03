using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownSharp;
using web.Models;
using web.Service.Model;
using System.Data.Entity;

namespace web.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Category(string name)
        {
            var viewModel = new CategoryViewModel();
            using (var database = new DataEntities())
            {
                var category = (from c in database.Categories
                                where c.Name.ToLower() == name.ToLower()
                                select c).FirstOrDefault();
                if (category == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                viewModel.Name = category.Name;
                viewModel.FeaturedItem = new ItemViewModel((from i in database.Items
                                          where i.Id == category.Featured
                                          select i).FirstOrDefault());
            }
            return View(viewModel);
        }
    }
}
