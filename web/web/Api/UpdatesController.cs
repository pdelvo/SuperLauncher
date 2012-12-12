using System;
using System.Web.Http;
using web.Models;

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
}
