using System.Web.Mvc;
using M13n.Models;

namespace M13n.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet()]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost()]
        public ActionResult Contact(ContactModel cm)
        {
            if (ModelState.IsValid)
            {
                // Send it into the void
                cm = new ContactModel();
            }

            return View(cm);
        }
    }
}
