using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyRecipe.Models
{
    public class RecipeIngredient
    {
        [Key]
        [Column(Order=1)]
        public int RecipeID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int IngredientID { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}