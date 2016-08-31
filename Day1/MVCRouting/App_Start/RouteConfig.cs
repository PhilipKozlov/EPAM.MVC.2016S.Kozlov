using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace ASP.NET.Day1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var defaultNamespace = "ASP.NET.Day1.Controllers";
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Json",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { id = new RangeRouteConstraint(1, 10) },
                namespaces: new [] { "JsonControllers" }
            );

            routes.MapRoute(
                name: "View",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { id = new RangeRouteConstraint(11, 100) },
                namespaces: new [] { "Controllers" }
            );

            routes.MapRoute(
                name: "Custom1",
                url: "{controller}/{action}/{type}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new { type = "json" },
                namespaces: new[] { "JsonControllers" }
            );

            routes.MapRoute(
                name: "Custom2",
                url: "{controller}/{action}/{type}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { type = "view" },
                namespaces: new[] { "Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { defaultNamespace }
            );

            routes.MapRoute(
                name: "Static",
                url: "Home/Index",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new [] { defaultNamespace }
            );
        }
    }
}
