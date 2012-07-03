using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MongoDB.Driver;
using nTextNetwork.Presentation.Web.Models;

namespace nTextNetwork.Presentation.Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            string connStr = ConfigurationManager.ConnectionStrings["db_ntextnetwork"].ConnectionString;
            string dbName = ConfigurationManager.AppSettings["db_name"];
            MongoServer server = MongoServer.Create(connStr);
            Db.Init(server, dbName);
        }
    }
}