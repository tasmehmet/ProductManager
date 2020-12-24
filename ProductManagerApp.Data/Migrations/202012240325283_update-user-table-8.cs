namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsersEntities");
        }
    }
}
