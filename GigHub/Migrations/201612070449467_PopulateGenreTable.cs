namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Classic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Pop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Alternative')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4,5)");
        }
    }
}
