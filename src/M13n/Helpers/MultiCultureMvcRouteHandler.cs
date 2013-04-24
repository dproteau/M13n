using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace M13n.Helpers
{

    public class MultiCultureMvcRouteHandler : MvcRouteHandler
    {
        private const string RouteDataCultureKey = "culture";
    
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var routeCultureName = requestContext.RouteData.Values[RouteDataCultureKey].ToString();
            var rci = new CultureInfo(routeCultureName);
            Thread.CurrentThread.CurrentUICulture = rci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(rci.Name);

            return base.GetHttpHandler(requestContext);
        }
    }

}