using LazyRecipe.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace LazyRecipe.DAL
{
    public class RecipeContext : DbContext
    {

        public RecipeContext() : base("RecipeContext")
        {
        }
 

        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        //public DbSet<RecipeCategory> RecipeCategories { get; set; }
        //public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Recipe>()
                        .HasMany<Ingredient>(s => s.Ingredients)
                        .WithMany(c => c.Recipes)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("RecipeRefId");
                            cs.MapRightKey("IngredientRefId");
                            cs.ToTable("RecipeIngredient");
                        });

        }

        //public System.Data.Entity.DbSet<LazyRecipe.Models.Recipe> Recipes { get; set; }

    }
}
