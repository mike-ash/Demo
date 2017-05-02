using Semi_Webshop.services;
using Semi_Webshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Semi_Webshop.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IMovieService movieService;

        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }


        public async Task<ActionResult> Index()
        {
            var deals = await movieService.GetDealsAsync();
            HomeIndexViewModel model = new HomeIndexViewModel() { Deals = deals.Take(3).ToList() };
            return View(model);
        }


    }
}