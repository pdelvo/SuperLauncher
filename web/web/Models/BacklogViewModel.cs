using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;

namespace web.Models
{
    public class BacklogViewModel
    {
        public BacklogViewModel()
        {
            Backlog = new List<Item>();
        }

        public List<Item> Backlog { get; set; }
    }
}