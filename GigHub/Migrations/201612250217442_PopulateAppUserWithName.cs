namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateAppUserWithName : DbMigration
    {
        public override void Up()
        {
            Sql("Update AspNetUsers SET Name = 'Robbie Williams'");
        }

        public override void Down()
        {
            Sql("Update AspNetUsers SET Name = null");
        }
    }
}
