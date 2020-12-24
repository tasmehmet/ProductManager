namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable7 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UsersEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersEntities",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idUser);
            
        }
    }
}
