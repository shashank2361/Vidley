namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (2,'Drama')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (3,'Crime')");

        }

        public override void Down()
        {
        }
    }
}
