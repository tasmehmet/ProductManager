namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImagesEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ImageSubText = c.String(),
                        ProductId = c.Int(nullable: false),
                        ProductEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductEntities", t => t.ProductEntity_Id)
                .Index(t => t.ProductEntity_Id);
            
            CreateTable(
                "dbo.ProductEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Barcode = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detail = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImagesEntities", "ProductEntity_Id", "dbo.ProductEntities");
            DropIndex("dbo.ProductImagesEntities", new[] { "ProductEntity_Id" });
            DropTable("dbo.ProductEntities");
            DropTable("dbo.ProductImagesEntities");
        }
    }
}
