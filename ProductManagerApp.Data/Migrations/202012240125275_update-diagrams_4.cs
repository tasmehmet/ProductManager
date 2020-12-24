namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatediagrams_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductImagesEntities", "ImageByte", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductImagesEntities", "ImageByte", c => c.Byte(nullable: false));
        }
    }
}
