﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using M13n.Helpers;

namespace M13n
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default route clone with explicit localization
            routes.MapRoute( 
                name: "MultiCulture", 
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            ).RouteHandler = new MultiCultureMvcRouteHandler();

            // Default route without explicit localization
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );

            LocalizeRoutes(routes);

        }

        /// <summary>
        /// Apply localization to MulticultureMvcRoutes
        /// </summary>
        /// <param name="routes">Routes list to apply localization if needed</param>
        private static void LocalizeRoutes(IEnumerable<RouteBase> routes, CultureIdentifier ci = 0)
        {
            CultureConstraint cc = null;

            foreach (Route r in routes)
            {
                if (r.RouteHandler is MultiCultureMvcRouteHandler)
                {
                    const string urlSegment = "{culture}/";
                    if (!r.Url.StartsWith(urlSegment))
                    {
                        r.Url = urlSegment + r.Url;
                    }

                    if (ci > 0)
                    {
                        //Adding default culture 
                        if (r.Defaults == null)
                        {
                            r.Defaults = new RouteValueDictionary();
                        }
                        //Set english as default culture
                        r.Defaults["culture"] = ci.ToString();
                    }

                    //Adding constraint for culture param
                    if (r.Constraints == null)
                    {
                        r.Constraints = new RouteValueDictionary();
                    }
                    r.Constraints["culture"] = cc ?? (cc = new CultureConstraint(Enum.GetNames(typeof (CultureIdentifier))));
                }
            }
        }
    }
}