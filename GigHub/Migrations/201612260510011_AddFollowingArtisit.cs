namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingArtisit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ArtistId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.ArtistId })
                .ForeignKey("dbo.AspNetUsers", t => t.ArtistId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "ArtistId" });
            DropIndex("dbo.Followings", new[] { "UserId" });
            DropTable("dbo.Followings");
        }
    }
}
