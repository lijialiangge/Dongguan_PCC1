using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eaton_DG_PCC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PCTron", action = "indexs", id = UrlParameter.Optional }
                //defaults: new { controller = "saiyuans", action = "indexs", id = UrlParameter.Optional }

            //routes.CreateArea("Root", "Git.Storage.Web.Controllers", routes.MapRoute("Root_Default", "{controller}/{action}", new { controller = "Home", action = "Index" }));


            );
        }
    }
}
