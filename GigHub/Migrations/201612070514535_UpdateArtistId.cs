namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArtistId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Gigs", "ArtistId");
            AddForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "ArtistId");
            AddForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
