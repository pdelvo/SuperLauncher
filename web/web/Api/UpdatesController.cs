using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Web.Http;
namespace web.Api
{
    public class UpdatesController : ApiController
    {
        //
        // GET: /Api/{version}/News
        public UpdatesCollection Get()
        {
            if ((DateTime.Now - MCUpdate.LastFetch).TotalMinutes > 10)
                MCUpdate.Fetch();
            return new UpdatesCollection(MCUpdate.Updates);
        }

    }

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
