using PagedList;
using Semi_Webshop.Models;
using Semi_Webshop.services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Semi_Webshop.Controllers
{
    public class MoviesController : Controller
    {
        protected readonly IMovieService movieService;
        protected readonly ISettingsService settingsService;


        public MoviesController(IMovieService movieService, ISettingsService settingsService)
        {
            this.movieService = movieService;
            this.settingsService = settingsService;
        }

        public async Task<ActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pagedResults = (await movieService.GetSeriesAsync()).ToPagedList(pageNumber, settingsService.PageSize);

            return View(pagedResults);
        }

        public async Task<ActionResult> Serie(string id)
        {
            Serie serie = await movieService.FindAsync(id);

            if (serie == null) return HttpNotFound();

            return View(serie);
        }
    }
}