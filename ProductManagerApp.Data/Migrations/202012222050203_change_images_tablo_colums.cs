namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_images_tablo_colums : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductImagesEntities", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductImagesEntities", "ProductId", c => c.Int(nullable: false));
        }
    }
}
