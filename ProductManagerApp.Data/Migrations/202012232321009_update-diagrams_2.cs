namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatediagrams_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductImagesEntities", "Product_Id", "dbo.ProductEntities");
            DropIndex("dbo.ProductImagesEntities", new[] { "Product_Id" });
            AddColumn("dbo.ProductImagesEntities", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductImagesEntities", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductImagesEntities", "Product_Id", c => c.Int());
            DropColumn("dbo.ProductImagesEntities", "ProductId");
            CreateIndex("dbo.ProductImagesEntities", "Product_Id");
            AddForeignKey("dbo.ProductImagesEntities", "Product_Id", "dbo.ProductEntities", "Id");
        }
    }
}
