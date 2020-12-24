namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersEntities", "RoleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersEntities", "RoleId");
        }
    }
}
