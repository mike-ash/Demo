using Semi_Webshop.Models;
using System.Web.Mvc;

namespace Semi_Webshop.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Terminator I" };
            return View(movie);
        }
    }
}