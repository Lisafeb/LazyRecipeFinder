namespace LazyRecipe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IngredientCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "IngredientCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredients", "IngredientCategory");
        }
    }
}
