namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatediagrams : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductImagesEntities", name: "ProductEntity_Id", newName: "Product_Id");
            RenameIndex(table: "dbo.ProductImagesEntities", name: "IX_ProductEntity_Id", newName: "IX_Product_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductImagesEntities", name: "IX_Product_Id", newName: "IX_ProductEntity_Id");
            RenameColumn(table: "dbo.ProductImagesEntities", name: "Product_Id", newName: "ProductEntity_Id");
        }
    }
}
