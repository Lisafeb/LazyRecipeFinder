using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LazyRecipe.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }

        public Ingredient()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public virtual ICollection<Recipe> Recipes { get; set; }

    }
}