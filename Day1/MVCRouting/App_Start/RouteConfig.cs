using CustomConstraints;
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
            var compoundConstraint = new CompoundRouteConstraint(new IRouteConstraint[] { new MinLengthRouteConstraint(3), new AlphaRouteConstraint() });
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
                name: "CustomSection1",
                url: "{controller}/{action}/{type}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new { type = "json" },
                namespaces: new[] { "JsonControllers" }
            );

            routes.MapRoute(
                name: "CustomSection2",
                url: "{controller}/{action}/{type}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { type = "view" },
                namespaces: new[] { "Controllers" }
            );

            routes.MapRoute(
                name: "Compound",
                url: "{controller}/{action}/{name}/{lastName}",
                defaults: new { controller = "Hello", action = "Index"},
                constraints: new { name = compoundConstraint, lastName = compoundConstraint },
                namespaces: new[] { defaultNamespace }
            );

            routes.MapRoute(
                name: "CustomConstraint",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { language = new LanguageConstraint("ru") },
                namespaces: new[] { "JsonControllers" }
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
