using LazyRecipe.DAL;
using LazyRecipe.Models;
using LazyRecipe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LazyRecipe.Controllers
{
    public class HomeController : Controller
    {

        private RecipeContext db = new RecipeContext();
        public ActionResult Index(Recipe recipe)
        {
            PopulateAssignedIngredienData();
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

        private void PopulateAssignedIngredienData()
        {
            var allIngredients = db.Ingredients;
            var viewModel = new List<Ingredien>();
            foreach (var ingredient in allIngredients)
            {
                viewModel.Add(new Ingredien
                {
                    IngredientID = ingredient.IngredientID,
                    IngredientName = ingredient.IngredientName,
                    IngredientCategory = ingredient.IngredientCategory
                });
            }
            ViewBag.Ingredients = viewModel;
        }

        


    }
}