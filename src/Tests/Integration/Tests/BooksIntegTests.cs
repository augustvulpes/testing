using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    public class BooksIntegTests
    {
        private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly DataContext dbContext;

        public BooksIntegTests()
        {
            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();
        }

        //[SkippableFact]
        //public void TestAdd()
        //{
        //    Skip.If(skip);

        //    var builder = new BookOM().CreateBook();
        //    var book = builder.buildDto();
        //    var builderAuthor = new AuthorOM().CreateAuthor();
        //    var author = builderAuthor.buildDto();

        //    var authorsService = DbHelper.GetRequiredService<AuthorService>();
        //    var result = authorsService.CreateAuthor(author);

        //    var bookService = DbHelper.GetRequiredService<BookService>();
        //    var created = bookService.CreateBook(author.Id, book);

        //    DbHelper.ClearDb();

        //    Assert.Equivalent("Successfully created", created);
        //}
    }
}
