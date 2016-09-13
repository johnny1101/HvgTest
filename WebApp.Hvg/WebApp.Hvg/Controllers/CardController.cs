using System.Web.Http;
using System.Web.Http.Results;
using WebApp.Hvg.Handlers;
using WebApp.Hvg.Interfaces.Handlers;

namespace WebApp.Hvg.Controllers
{
    public class CardController : ApiController
    {
        private readonly ITrelloCardHandler _trelloCardHandler;

        public CardController()
        {
            _trelloCardHandler = new TrelloCardHandler();
        }

        public JsonResult<string> Get(string sha1Id)
        {
            var trelloCard = _trelloCardHandler.Get(sha1Id);
            var trelloCardUrl = trelloCard.Commit != null && !string.IsNullOrWhiteSpace(trelloCard.Commit.ShortUrl)
                ? string.Format("{0}{1}", Properties.Settings.Default.TrelloCardUrl, trelloCard.Commit.ShortUrl)
                : string.Empty;

            return this.Json(trelloCardUrl);
        }
    }
}
