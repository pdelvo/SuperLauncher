using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace web.Models
{
    [DataContract(Name = "item")]
    public class DetailedItem
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
    public class DetailedItemCollection : Collection<DetailedItem>
    {
        public DetailedItemCollection()
        {

        }
        public DetailedItemCollection(IList<DetailedItem> updates)
            : base(updates)
        {

        }
    }
}