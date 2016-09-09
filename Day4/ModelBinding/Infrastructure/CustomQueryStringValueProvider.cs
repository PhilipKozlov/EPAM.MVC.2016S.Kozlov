using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
    public class CustomQueryStringValueProvider : CustomValueProvider
    {
        public CustomQueryStringValueProvider(ControllerContext controllerContext) : base(controllerContext.HttpContext.Request.QueryString) { }
    }
}