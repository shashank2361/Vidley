namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Movies ( Name,GenreId,ReleaseDate,DateAdded,NumberInStock) " +
                "Values('Terminator1',1,'19880301','20121229','14')");

            Sql("Insert Into Movies ( Name,GenreId,ReleaseDate,DateAdded,NumberInStock) " +
                "Values('KingsMan',2,'20160102','20161029','20')");

            Sql("Insert Into Movies ( Name,GenreId,ReleaseDate,DateAdded,NumberInStock) " +
                "Values('MazeRunner',3,'20000102','20001029','20')");

        }

        public override void Down()
        {
        }
    }
}
