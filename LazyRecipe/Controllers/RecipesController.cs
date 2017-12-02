using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LazyRecipe.Models;

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,RecipeName,Time,MainPicture,Instructions,UserID")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,RecipeName,Time,MainPicture,Instructions,UserID")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
    }
}
