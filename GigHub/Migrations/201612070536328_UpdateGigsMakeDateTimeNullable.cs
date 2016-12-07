namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGigsMakeDateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gigs", "DateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gigs", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
