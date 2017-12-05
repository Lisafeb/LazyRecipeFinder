using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LazyRecipe.Models;
using LazyRecipe.ViewModels;
using System.Data.Entity.Infrastructure;

namespace LazyRecipe.DAL
{
    public class RecipesController : Controller
    {
       
        private RecipeContext db = new RecipeContext();

        // GET: Recipes
        public ViewResult Index(string sortOrder, string searchString)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable recipes;
            if (String.IsNullOrEmpty(searchString))
            {
                recipes = db.Recipes;
            }
            else
            {
                recipes = db.Recipes.Where(r => r.Ingredients.Any(i => i.IngredientName == searchString));
            }
            //var Recipes = db.Recipes.Where(r => r.Ingredients.Where(i => i.))
            ////var Recipes = db.Recipes.Find(1);


            //if (!String.IsNullOrEmpty(searchString)) {
            //    db.Entry(Recipes)
            //    .Collection(r => r.RecipeIngredients.Where(i => i.).
            //    .Query()
            //    .Where(i => i.  Ingredient.IngredientName.Contains(searchString));

            //}
            //));
            //var Recipes = db.Recipes.Find(1);


            //if (!String.IsNullOrEmpty(searchString)) {
            //    db.Entry(Recipes)
            //    .Collection(r => r.RecipeIngredients.Where(i => i.).
            //    .Query()
            //    .Where(i => i.  Ingredient.IngredientName.Contains(searchString));

            //}



            //switch (sortOrder)
            //{
            //    case "name_desc":
            //     Recipes = Recipes.OrderByDescending(s => s.RecipeName);
            //     break;

            //  default:
            //       Recipes = Recipes.OrderBy(s => s.RecipeName);
            //      break;
            //}
            return View(recipes);
        }

        
// GET: Recipes/Details/5
public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

		// GET: Recipes/Create
		//public ActionResult Create(Recipe recipe)
		//{
  //          PopulateAssignedIngredientData(recipe);
		//	return View();
		//}

		// POST: Recipes/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,RecipeName,Time,MainPicture,Instructions,UserID, IngredientID")] Recipe recipe)
        {
			try
			{
				if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			}
			catch (RetryLimitExceededException /* dex */)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.) 
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
			}
            PopulateAssignedIngredientData(recipe);
				return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes
            .Include(i => i.Ingredients)
            .Where(i => i.RecipeID == id)
            .Single();
            PopulateAssignedIngredientData(recipe);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            
			return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,RecipeName,Time,MainPicture,Instructions,UserID")] Recipe recipe)
        {
			try
			{
				if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			}
			catch (RetryLimitExceededException /* dex */)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.) 
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
			}
            PopulateAssignedIngredientData(recipe);
			return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateAssignedIngredientData(Recipe recipe)
        {
            var allIngredients = db.Ingredients;
            var recipeIngredients = new HashSet<int>(recipe.Ingredients.Select(c => c.IngredientID));
            var viewModel = new List<AssignedIngredients>();
            foreach (var ingredient in allIngredients)
            {
                viewModel.Add(new AssignedIngredients
                {
                    IngredientID = ingredient.IngredientID,
                    IngredientName = ingredient.IngredientName,
                    Assigned = recipeIngredients.Contains(ingredient.IngredientID)
                });
            }
            ViewBag.Ingredients = viewModel;
        }

        private void UpdateRecipeIngredients(string[] selectedIngredients, Recipe recipeToUpdate) {
            if (selectedIngredients == null) {
                recipeToUpdate.Ingredients = new List<Ingredient>();
                return;
            }

            var selectedIngredientsHS = new HashSet<string>(selectedIngredients);
            var recipeIngredients = new HashSet<int>(recipeToUpdate.Ingredients.Select(c => c.IngredientID));
            foreach (var ingredient in db.Ingredients) {
                if (selectedIngredientsHS.Contains(ingredient.IngredientID.ToString())) {
                    if (!recipeIngredients.Contains(ingredient.IngredientID)) { recipeToUpdate.Ingredients.Add(ingredient); } }
                else { if (recipeIngredients.Contains(ingredient.IngredientID)) { recipeToUpdate.Ingredients.Remove(ingredient); } } } }
    }
 }
        
