using System.Web.Http;
using Manatee.Trello;
using Manatee.Trello.ManateeJson;
using Manatee.Trello.RestSharp;

namespace WebApp.Hvg
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var serializer = new ManateeSerializer();
            TrelloConfiguration.Serializer = serializer;
            TrelloConfiguration.Deserializer = serializer;
            TrelloConfiguration.JsonFactory = new ManateeFactory();
            TrelloConfiguration.RestClientProvider = new RestSharpClientProvider();

            TrelloAuthorization.Default.AppKey = Properties.Settings.Default.TrelloAppKey;
            TrelloAuthorization.Default.UserToken = Properties.Settings.Default.TrelloUserToken;
        }
    }
}
