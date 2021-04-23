using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OperasWebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //la ruta personalizada siempre va por encima de la default
            routes.MapRoute(
                name: "AdminLogin",
                url: "Admin/Login/{id}/{role}",
                defaults: new { controller = "Admin", action="Login"},
                constraints: new { id = "^[1-9]\\d{0,2}$" }  //acepta numeros positivos hasta el 999
                );

            //la ruta personalizada siempre va por encima de la default
            routes.MapRoute(
                name: "AdminSearchName",
                url: "Admin/{name}",
                defaults: new { controller = "Admin", action = "SearchByName" }
                );

            //default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
