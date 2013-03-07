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
        //
        // GET: /Culture/

        [AllowAnonymous]
        public ActionResult ChangeCulture(CultureIdentifier lang, string returnUrl, string culture)
        {
            //var urlParts = returnUrl.Split(new char[] {'/', '\\'});
            var urlParts = returnUrl.Split('/');

            if (urlParts.Contains(culture))
            {
                urlParts[Array.IndexOf(urlParts, culture)] = lang.ToString();
                return Redirect(string.Join("/", urlParts));
            }
            return Redirect("/" + lang + string.Join("/", urlParts));
        }

    }
}
