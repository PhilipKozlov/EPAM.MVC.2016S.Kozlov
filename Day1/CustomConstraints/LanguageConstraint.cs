using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace CustomConstraints
{
    public class LanguageConstraint : IRouteConstraint
    {
        #region Fields
        string language;
        #endregion

        #region Constructors
        public LanguageConstraint(string name)
        {
            this.language = name;
        }
        #endregion

        #region Public Methods
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.UserLanguages.Contains(language);
        }
        #endregion
    }
}
