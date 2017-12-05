using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LazyRecipe.ViewModels
{
    public class AssignedIngredients
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public bool Assigned { get; set; }
    }
}