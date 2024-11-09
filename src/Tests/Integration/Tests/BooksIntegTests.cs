using LibraryApp.Data;
using LibraryApp.Dto;
using LibraryApp.Interfaces.ServiceInterfaces;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [Collection(nameof(NonParallelCollection))]
    public class BooksIntegTests
    {
        //private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly bool skip = true;
        private readonly DataContext dbContext;

        public BooksIntegTests()
        {
            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();
        }

        ~BooksIntegTests()
        {
            DbHelper.ClearDb();
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(skip);

            var builder = new BookOM().CreateBook();
            var book = builder.buildDto();

            var builderAuthor = new AuthorOM().CreateAuthor();
            var author = builderAuthor.buildDto();
            //dbContext.Authors.Add(author);

            var authorsService = DbHelper.GetRequiredService<AuthorService>();
            var result = authorsService.CreateAuthor(author);

            var bookService = DbHelper.GetRequiredService<BookService>();
            var created = bookService.CreateBook(author.Id, book);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", created);
        }

        [SkippableFact]
        public void GetBooks()
        {
            Skip.If(skip);
            //var testAuthor = new AuthorDto { Id = 1230, Country = "TEST", Name = "TEST002" };

            //_authorService.CreateAuthor(testAuthor);

            var builderAuthor = new AuthorOM().CreateAuthor();
            var author = builderAuthor.buildDto();
            //dbContext.Authors.Add(author);

            var authorsService = DbHelper.GetRequiredService<AuthorService>();
            var result = authorsService.CreateAuthor(author);
            var builders = new BookOM().CreateRange();
            var books = builders.Select(b => b.buildDto()).ToList();

            //var testBook1 = new BookDto { Id = 9990, Year = 2000, BBK = "aaa", Pages = 42, Title = "TEST1" };
            //var testBook2 = new BookDto { Id = 9991, Year = 2000, BBK = "aaa", Pages = 42, Title = "TEST2" };

            //var books = new List<BookDto> { testBook1, testBook2 };

            var bookService = DbHelper.GetRequiredService<BookService>();

            bookService.CreateBook(author.Id, books[0]);
            bookService.CreateBook(author.Id, books[1]);

            var resultBooks = bookService.GetBooks();

            //_bookService.DeleteBook(testBook1.Id);
            //_bookService.DeleteBook(testBook2.Id);
            //_authorService.DeleteAuthor(testAuthor.Id);

            DbHelper.ClearDb();

            Assert.Equivalent(books, resultBooks);
        }
    }
}
