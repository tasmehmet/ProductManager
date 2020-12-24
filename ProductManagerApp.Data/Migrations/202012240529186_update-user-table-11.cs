namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UsersEntities", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersEntities", "ConfirmPassword", c => c.String());
        }
    }
}
