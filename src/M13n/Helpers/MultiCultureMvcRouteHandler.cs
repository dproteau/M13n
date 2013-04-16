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
            var routeDataCultureName = requestContext.RouteData.Values[RouteDataCultureKey].ToString();
            var rdc = new CultureInfo(routeDataCultureName);
            Thread.CurrentThread.CurrentUICulture = rdc;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(rdc.Name);

            return base.GetHttpHandler(requestContext);
        }
    }

}