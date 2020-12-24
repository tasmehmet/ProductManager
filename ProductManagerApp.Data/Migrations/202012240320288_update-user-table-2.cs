namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UsersEntities");
            AddColumn("dbo.UsersEntities", "idUser", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UsersEntities", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.UsersEntities", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.UsersEntities", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UsersEntities", "Password", c => c.String(nullable: false));
            AddPrimaryKey("dbo.UsersEntities", "idUser");
            DropColumn("dbo.UsersEntities", "Id");
            DropColumn("dbo.UsersEntities", "Name");
            DropColumn("dbo.UsersEntities", "Mail");
            DropColumn("dbo.UsersEntities", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersEntities", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.UsersEntities", "Mail", c => c.String());
            AddColumn("dbo.UsersEntities", "Name", c => c.String());
            AddColumn("dbo.UsersEntities", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UsersEntities");
            AlterColumn("dbo.UsersEntities", "Password", c => c.String());
            DropColumn("dbo.UsersEntities", "Email");
            DropColumn("dbo.UsersEntities", "LastName");
            DropColumn("dbo.UsersEntities", "FirstName");
            DropColumn("dbo.UsersEntities", "idUser");
            AddPrimaryKey("dbo.UsersEntities", "Id");
        }
    }
}
