namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowersToAppUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "UserId", "dbo.AspNetUsers");
            CreateTable(
                "dbo.ApplicationUserApplicationUsers",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ApplicationUser_Id1 })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            AddForeignKey("dbo.Followings", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserApplicationUsers");
            AddForeignKey("dbo.Followings", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
