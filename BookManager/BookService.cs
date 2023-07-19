using BookManager.Context;
using Dapper;

namespace BookManager
{
    public class BookService
    {
        private readonly DapperContext context;
        public BookService(DapperContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            using var dbConnection = context.CreateConnection();
            var books = await dbConnection.QueryAsync<Book>("Select * from dbo.Books");
            return books.ToList();
        }
        public async Task<Book> CreateAsync(Book book)
        {
            using var dbConnection = context.CreateConnection();
            book.Id = Guid.NewGuid();
            var result = await dbConnection.ExecuteAsync("Insert INTO Books (Id,Name,Author,PublishedYear) Values (@Id, @Name, @Author, @PublishedYear)", book);
            return book;
        }
    }
}
