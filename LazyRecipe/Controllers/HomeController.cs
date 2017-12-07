using LazyRecipe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyRecipe.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            return RedirectToAction("Index", "Recipes");
        }

        public ActionResult RecipeIndex(string searchString)
        {
            ViewBag.Message = searchString;
            return View();
        }




    }
}