using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace web.Models
{
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