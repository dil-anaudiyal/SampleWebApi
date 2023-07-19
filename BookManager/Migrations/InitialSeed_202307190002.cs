using FluentMigrator;

namespace BookManager.Migrations
{
    [Migration(202307190002)]
    public class InitialSeed_202307190002 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Books")
                .Row(new Book
                {
                    Id = new Guid("59c0d403-71ce-4ac8-9c2c-b0e54e7c043b"),
                    Name = "TestBook",
                    Author = "ashish",
                    PublishedYear = 2009
                });
        }
        public override void Up()
        {
            Insert.IntoTable("Books")
                .Row(new Book
                {
                    Id = new Guid("59c0d403-71ce-4ac8-9c2c-b0e54e7c043b"),
                    Name = "TestBook",
                    Author = "ashish",
                    PublishedYear = 2009
                });
        }
    }
}
