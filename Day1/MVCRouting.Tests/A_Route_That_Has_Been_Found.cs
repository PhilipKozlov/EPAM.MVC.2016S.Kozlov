using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRouting.Tests
{
    using Machine.Specifications;
    using System.Web.Routing;
    [Behaviors]
    public class A_Route_That_Has_Been_Found
    {
        protected static RouteData routeData;

        It should_have_found_the_route = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("home");
            routeData.Values["Action"].ShouldEqual("index");
        };
    }
}
