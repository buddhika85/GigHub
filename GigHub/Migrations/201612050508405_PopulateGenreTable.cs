namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Country')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Classics')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Blues')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Gernres WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
