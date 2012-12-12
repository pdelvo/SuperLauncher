using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace web.Models
{
    [CollectionDataContract(Name = "updates", Namespace = "")]
    public class UpdatesCollection : Collection<MCUpdate.Update>
    {
        public UpdatesCollection()
        {
            
        }
        public UpdatesCollection(IList<MCUpdate.Update> updates)
            :base(updates)
        {
            
        }
    }
}