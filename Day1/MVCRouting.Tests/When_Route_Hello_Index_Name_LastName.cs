using Moq;
using System.Web.Mvc;
using System.Web.Routing;
using ASP.NET.Day1;
using System.Web;
using Machine;

namespace MVCRouting.Tests
{
    using Machine.Specifications;

    [Subject("Routing")]
    public class When_Route_Hello_Index_Name_LastName
    {
        static RouteCollection routes;
        static Mock<HttpContextBase> httpContextMock;
        static RouteData routeData;

        Establish that = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/hello/index/Philipp/Kozlov");
        };

        Because of = () => routeData = routes.GetRouteData(httpContextMock.Object);

        It should_have_found_route_for_hello_index_name_lastName = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("hello");
            routeData.Values["Action"].ShouldEqual("index");
            routeData.Values["Name"].ShouldEqual("Philipp");
            routeData.Values["LastName"].ShouldEqual("Kozlov");
        };

    }
}
