namespace Queste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner = c.String(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Answear = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Roles", "RoleId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Roles", new[] { "Id" });
            AddPrimaryKey("dbo.Roles", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "RoleId");
            CreateIndex("dbo.Users", "RoleId");
            DropColumn("dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Id", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropPrimaryKey("dbo.Roles", new[] { "RoleId" });
            AddPrimaryKey("dbo.Roles", "Id");
            DropColumn("dbo.Roles", "RoleId");
            DropColumn("dbo.Users", "UserName");
            DropTable("dbo.Quests");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
    }
}
