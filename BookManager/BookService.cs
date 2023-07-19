using Microsoft.Extensions.Options;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookManager
{
    public class BookService
    {
        private readonly IServiceProvider serviceProvider;

        public BookService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var dbConnection = serviceProvider.GetService<IDbConnection>();
            return await dbConnection.QueryAsync<Book>("Select * from dbo.Books");
        }
        public async Task<Book> CreateAsync(Book book)
        {
            var dbConnection = serviceProvider.GetService<IDbConnection>();
            book.Id = Guid.NewGuid();
            await dbConnection.ExecuteAsync("Insert INTO Books (Id,Name,Author,PublishedYear) Values (@Id, @Name, @Author, @PublishedYear)", book);
            return book;
        }
    }
}
