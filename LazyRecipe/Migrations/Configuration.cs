namespace LazyRecipe.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LazyRecipe.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<LazyRecipe.DAL.RecipeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LazyRecipe.DAL.RecipeContext context)
        {
            {
                var users = new List<User>
                {
                new User{Username="Karo", Email="karo@email.com", Password="1dd",UserID=1 }
                };
                users.ForEach(u => context.Users.AddOrUpdate(u));
                context.SaveChanges();
            }


            var ingredient = new List<Ingredient> { new Ingredient { IngredientID=3, IngredientName = "oil" },
                new Ingredient { IngredientID = 4, IngredientName = "garlic" },
                new Ingredient { IngredientID = 5, IngredientName = "chicken" },
                new Ingredient { IngredientID = 6, IngredientName = "curry" },
                new Ingredient { IngredientID = 7, IngredientName = "pepper" },
                new Ingredient { IngredientID = 8, IngredientName = "tomato" },
                new Ingredient { IngredientID = 9, IngredientName = "pumpkin" },
                new Ingredient { IngredientID = 10, IngredientName = "beans" }

            };


            ingredient.ForEach(c => context.Ingredients.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}


