namespace LazyRecipe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                    })
                .PrimaryKey(t => t.IngredientID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        Time = c.Int(nullable: false),
                        MainPicture = c.String(),
                        Instructions = c.String(storeType: "xml"),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.RecipeIngredient",
                c => new
                    {
                        RecipeRefId = c.Int(nullable: false),
                        IngredientRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeRefId, t.IngredientRefId })
                .ForeignKey("dbo.Recipes", t => t.RecipeRefId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientRefId, cascadeDelete: true)
                .Index(t => t.RecipeRefId)
                .Index(t => t.IngredientRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredient", "IngredientRefId", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredient", "RecipeRefId", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredient", new[] { "IngredientRefId" });
            DropIndex("dbo.RecipeIngredient", new[] { "RecipeRefId" });
            DropTable("dbo.RecipeIngredient");
            DropTable("dbo.Users");
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
        }
    }
}
