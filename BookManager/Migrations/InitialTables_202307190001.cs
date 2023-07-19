using FluentMigrator;

namespace BookManager.Migrations
{
    [Migration(202307190001)]
    public class InitialTables_202307190001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Books");
        }
        public override void Up()
        {
            Create.Table("Books")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Author").AsString(60).NotNullable()
                .WithColumn("PublishedYear").AsInt64().NotNullable();
        }
    }
}
