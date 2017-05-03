using Semi_Webshop.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semi_Webshop.Controllers
{
    public class ShoppingCartController : Controller
    {

        protected readonly IShoppingCartService shoppingCartService;
        protected readonly IMovieService movieService;
        protected readonly IFinanceService financeService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IMovieService movieService, IFinanceService financeService)
        {
            this.shoppingCartService = shoppingCartService;
            this.movieService = movieService;
            this.financeService = financeService;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
    }
}