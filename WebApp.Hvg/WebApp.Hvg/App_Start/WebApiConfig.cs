using System.Web.Http;

namespace WebApp.Hvg
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SearchCard", 
                routeTemplate: "Search/Card/sha1id",
                defaults: new { sha1id = (string)null });

            config.Routes.MapHttpRoute(
                name: "SearchCommit",
                routeTemplate: "Search/Commit/shorturl",
                defaults: new { shorturl = (string)null });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Search/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
