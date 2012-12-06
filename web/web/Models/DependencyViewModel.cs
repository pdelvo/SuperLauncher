using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;

namespace web.Models
{
    public class DependencyViewModel
    {
        public DependencyViewModel(Dependency dependnecy)
        {
            Provider = new ItemViewModel(dependnecy.Provider);
            Dependent = new ItemViewModel(dependnecy.Dependent);
            Id = dependnecy.Id;
        }

        public ItemViewModel Provider { get; set; }
        public ItemViewModel Dependent { get; set; }
        public int Id { get; set; }
    }
}