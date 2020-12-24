namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersEntities", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.UsersEntities", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.UsersEntities", "Email", c => c.String());
            AlterColumn("dbo.UsersEntities", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UsersEntities", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.UsersEntities", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UsersEntities", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.UsersEntities", "ConfirmPassword");
        }
    }
}
