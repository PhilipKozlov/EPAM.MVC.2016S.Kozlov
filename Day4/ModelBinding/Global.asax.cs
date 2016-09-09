using ModelBinding.Infrastructure;
using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ModelBinding
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());
            ModelBinders.Binders.Add(typeof(Person), new PersonModelBinder());
        }
    }
}
