using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyRecipe.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public int Time { get; set; }
        public string MainPicture { get; set; }

        [Column(TypeName = "xml")]
        public string Instructions { get; set; }

        public int UserID { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; }


    }
}

//30.11.2017