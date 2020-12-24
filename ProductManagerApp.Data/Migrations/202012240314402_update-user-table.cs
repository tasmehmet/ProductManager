namespace ProductManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "UsersEntities");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.UsersEntities", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropPrimaryKey("dbo.UsersEntities");
            CreateTable(
                "dbo.RoleEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UsersEntities", "Name", c => c.String());
            AddColumn("dbo.UsersEntities", "Mail", c => c.String());
            AddColumn("dbo.UsersEntities", "Password", c => c.String());
            AddColumn("dbo.UsersEntities", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.UsersEntities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UsersEntities", "Id");
            DropColumn("dbo.UsersEntities", "Email");
            DropColumn("dbo.UsersEntities", "EmailConfirmed");
            DropColumn("dbo.UsersEntities", "PasswordHash");
            DropColumn("dbo.UsersEntities", "SecurityStamp");
            DropColumn("dbo.UsersEntities", "PhoneNumber");
            DropColumn("dbo.UsersEntities", "PhoneNumberConfirmed");
            DropColumn("dbo.UsersEntities", "TwoFactorEnabled");
            DropColumn("dbo.UsersEntities", "LockoutEndDateUtc");
            DropColumn("dbo.UsersEntities", "LockoutEnabled");
            DropColumn("dbo.UsersEntities", "AccessFailedCount");
            DropColumn("dbo.UsersEntities", "UserName");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UsersEntities", "UserName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.UsersEntities", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.UsersEntities", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersEntities", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.UsersEntities", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersEntities", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersEntities", "PhoneNumber", c => c.String());
            AddColumn("dbo.UsersEntities", "SecurityStamp", c => c.String());
            AddColumn("dbo.UsersEntities", "PasswordHash", c => c.String());
            AddColumn("dbo.UsersEntities", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersEntities", "Email", c => c.String(maxLength: 256));
            DropPrimaryKey("dbo.UsersEntities");
            AlterColumn("dbo.UsersEntities", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UsersEntities", "RoleId");
            DropColumn("dbo.UsersEntities", "Password");
            DropColumn("dbo.UsersEntities", "Mail");
            DropColumn("dbo.UsersEntities", "Name");
            DropTable("dbo.RoleEntities");
            AddPrimaryKey("dbo.UsersEntities", "Id");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.UsersEntities", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.UsersEntities", newName: "AspNetUsers");
        }
    }
}
