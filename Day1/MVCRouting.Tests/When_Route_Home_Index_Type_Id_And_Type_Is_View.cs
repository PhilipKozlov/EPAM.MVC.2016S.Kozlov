using Moq;
using System.Web.Routing;
using ASP.NET.Day1;
using System.Web;
using Machine;

namespace MVCRouting.Tests
{
    using Machine.Specifications;

    [Subject("Routing")]
    public class When_Route_Home_Index_Type_Id_And_Type_Is_View
    {
        static RouteCollection routes;
        static Mock<HttpContextBase> httpContextMock;
        protected static RouteData routeData;

        Establish that = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/home/index/view/1");
        };

        Because of = () => routeData = routes.GetRouteData(httpContextMock.Object);

        Behaves_like<A_Route_That_Has_Been_Found> a_route_that_has_been_found;

        It should_have_type_of_view_and_id_1 = () =>
        {
            routeData.Values["Type"].ShouldEqual("view");
            routeData.Values["Id"].ShouldEqual("1");
        };

    }
}