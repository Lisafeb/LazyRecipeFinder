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


            var ingredient = new List<Ingredient>{
                new Ingredient { IngredientID=1, IngredientName = "apple", IngredientCategory = 1 },
                new Ingredient { IngredientID=2, IngredientName = "orange", IngredientCategory = 1 },
                new Ingredient { IngredientID=3, IngredientName = "banana", IngredientCategory = 1 },
                new Ingredient { IngredientID=4, IngredientName = "strawberry", IngredientCategory = 1 },
                new Ingredient { IngredientID = 5, IngredientName = "garlic", IngredientCategory = 0 },
                new Ingredient { IngredientID = 6, IngredientName = "chicken", IngredientCategory = 2 },
                new Ingredient { IngredientID = 7, IngredientName = "pork", IngredientCategory = 2 },
                new Ingredient { IngredientID = 8, IngredientName = "beef", IngredientCategory = 2 },
                new Ingredient { IngredientID = 9, IngredientName = "turkey", IngredientCategory = 2 },
                new Ingredient { IngredientID = 10, IngredientName = "milk", IngredientCategory = 3 },
                new Ingredient { IngredientID = 11, IngredientName = "cheese", IngredientCategory = 3 },
                new Ingredient { IngredientID = 12, IngredientName = "yoghurt", IngredientCategory = 3 },
                new Ingredient { IngredientID = 13, IngredientName = "cottage cheese", IngredientCategory = 3 },
                new Ingredient { IngredientID = 14, IngredientName = "flour", IngredientCategory = 4 },
                new Ingredient { IngredientID = 15, IngredientName = "buckwheat", IngredientCategory = 4 },
                new Ingredient { IngredientID = 16, IngredientName = "rice", IngredientCategory = 4 },
                new Ingredient { IngredientID = 17, IngredientName = "wheat", IngredientCategory = 4 },
                new Ingredient { IngredientID = 18, IngredientName = "tomato", IngredientCategory = 0 },
                new Ingredient { IngredientID = 19, IngredientName = "pumpkin", IngredientCategory = 0 },
                new Ingredient { IngredientID = 20, IngredientName = "potato", IngredientCategory = 0 },
                new Ingredient { IngredientID = 21, IngredientName = "salt", IngredientCategory = 5 },
                new Ingredient { IngredientID = 22, IngredientName = "pepper", IngredientCategory = 5 },
                new Ingredient { IngredientID = 23, IngredientName = "parsley", IngredientCategory = 5 },
                new Ingredient { IngredientID = 24, IngredientName = "chilli", IngredientCategory = 5 }

            };


            ingredient.ForEach(c => context.Ingredients.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}


