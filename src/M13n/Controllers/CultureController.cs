using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M13n.Helpers;

namespace M13n.Controllers
{
    public class CultureController : Controller
    {
 
        /// <summary>
        /// Change (or add) the culture in the return URL and redirect to the new return URL.
        /// </summary>
        /// <param name="lang">We want to set the culture to this language</param>
        /// <param name="returnUrl">The return URL</param>
        /// <param name="culture">The current culture</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ChangeCulture(CultureIdentifier lang, string returnUrl, string culture)
        {
            if (returnUrl == null) throw new ArgumentNullException("returnUrl");
            if (culture == null) throw new ArgumentNullException("culture");

            var urlParts = returnUrl.Split('/');

            if (urlParts.Contains(culture))
            {
                urlParts[Array.IndexOf(urlParts, culture)] = lang.ToString();
                return Redirect(string.Join("/", urlParts));
            }
            return Redirect("/" + lang.ToString() + string.Join("/", urlParts));
        }

    }
}
