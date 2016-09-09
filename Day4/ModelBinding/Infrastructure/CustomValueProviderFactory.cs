using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
    public class CustomValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            var provider = ConfigurationManager.AppSettings["ValueProvider"];
            //var type = DependencyResolver.Current.GetService(targetType);
            return Activator.CreateInstance(Type.GetType(provider)) as IValueProvider;
        }
    }
}