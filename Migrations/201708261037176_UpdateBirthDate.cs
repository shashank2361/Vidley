namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '19800101' WHERE Id = 1 ");

        }

        public override void Down()
        {
        }
    }
}
