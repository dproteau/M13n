using System.Web.Mvc;
using M13n.Models;

namespace M13n.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet()]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet()]
        public ActionResult Contact()
        {
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
