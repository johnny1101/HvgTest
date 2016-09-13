using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using WebApp.Hvg.Domain;
using WebApp.Hvg.Handlers;
using WebApp.Hvg.Interfaces.Handlers;

namespace WebApp.Hvg.Controllers
{
    public class CommitController : ApiController
    {
        private readonly IPushEventHandler _pushEventHandler;

        public CommitController()
        {
            _pushEventHandler = new PushEventHandler();
        }

        public JsonResult<IEnumerable<string>> Get(string shorturl)
        {
            var commits = _pushEventHandler.GetCommitsByShortUrl(shorturl);
            var sha1Keys = commits.Select(commit => commit.Sha).ToArray();

            return this.Json<IEnumerable<string>>(sha1Keys);
        }

        //[HttpPost]
        public void Post([FromBody] PushEvent push)
        {
            _pushEventHandler.Save(push);
        }
    }
}
