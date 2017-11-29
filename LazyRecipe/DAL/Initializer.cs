using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LazyRecipe.Models;

namespace LazyRecipe.DAL
{
    public class Initializer : System.Data.Entity.
   DropCreateDatabaseIfModelChanges<RecipeContext>
    {
        protected override void Seed(RecipeContext context)
        {
            var users = new List<User>
 {
new User{Username="Karo", Email="karo@email.com", Password="1dd",UserID=1 }
};
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var recipe = new List<Recipe>
            {
                new Recipe {RecipeID= 1, RecipeName="Chicken Soup", Time=25, MainPicture="01", Instructions="soup", UserID=1 } };

            recipe.ForEach(c => context.Recipes.Add(c));
            context.SaveChanges();

            var ingredient = new List<Ingredient> { new Ingredient { IngredientName = "water" }, new Ingredient { IngredientName = "salt" } };
            ingredient.ForEach(c => context.Ingredients.Add(c));
            context.SaveChanges();

            var recipeingredient = new List<RecipeIngredient> { new RecipeIngredient { RecipeID = 1, IngredientID = 1 } };
            recipeingredient.ForEach(c => context.RecipeIngredients.Add(c));
            context.SaveChanges();

            var categories = new List<Category> { new Category { CategoryName = "soups", CategoryID=1 } };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var recipecategory = new List<RecipeCategory> { new RecipeCategory { RecipeID = 1, CategoryID = 1 } };
            recipecategory.ForEach(c => context.RecipeCategories.Add(c));
            context.SaveChanges();

        }
    }
}