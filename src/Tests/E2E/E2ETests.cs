using LibraryApp.Controllers;
using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.Tests.Integration.Tests;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace LibraryApp.Tests.E2E
{
    [Collection(nameof(NonParallelCollection))]
    public class E2ETests
    {
        private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly DataContext dbContext;
        private readonly BookController bookController;
        private readonly AuthorController authorController;
        private readonly CollectionController collectionController;

        public E2ETests() 
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());

            bookController = new BookController(
                DbHelper.GetRequiredService<BookService>(),
                factory.CreateLogger<BookController>()
            );
            authorController = new AuthorController(
                DbHelper.GetRequiredService<AuthorService>(),
                factory.CreateLogger<AuthorController>()
            );
            collectionController = new CollectionController(
                DbHelper.GetRequiredService<CollectionService>(),
                factory.CreateLogger<CollectionController>()
            );

            dbContext = DbHelperE2E.GetContext();
            DbHelperE2E.ClearDb();
        }

        ~E2ETests() 
        {
            DbHelperE2E.ClearDb();
        }

        [SkippableFact]
        public void createAuthorAndBook()
        {
            Skip.If(skip);

            var builder = new BookOM().CreateBook();
            var book = builder.buildDto();
            var builderAuthor = new AuthorOM().CreateAuthor();
            var author = builderAuthor.buildDto();

            var resultAuthor = authorController.CreateAuthor(author);
            var resultBook = bookController.CreateBook(author.Id, book) as OkObjectResult;

            DbHelperE2E.ClearDb();

            Assert.IsType<OkObjectResult>(resultBook);
            Assert.Equivalent(HttpStatusCode.OK, resultBook.StatusCode);
        }

        [SkippableFact]
        public void addBookIntoCollection()
        {
            Skip.If(skip);

            var builder = new BookOM().CreateBook();
            var book = builder.build();

            var builderCollection = new CollectionOM().CreateCollection();
            var collection = builderCollection.buildDto();

            var builderAuthor = new AuthorOM().CreateAuthor();
            var author = builderAuthor.build();

            //var resultAuthor = authorController.CreateAuthor(author);
            //var resultBook = bookController.CreateBook(author.Id, book);
            dbContext.Authors.Add(author);
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
            var resultCollection = collectionController.CreateCollection(collection);
            var result = bookController.AddIntoCollection(collection.Id, book.Id) as OkObjectResult;

            DbHelperE2E.ClearDb();

            Assert.IsType<OkObjectResult>(result);
            Assert.Equivalent(HttpStatusCode.OK, result.StatusCode);
        }

        //[SkippableFact]
        //public void createAuthor()
        //{
        //    Skip.If(skip);

        //    var builder = new AuthorOM().CreateAuthor();
        //    var author = builder.buildDto();

        //    var result = authorController.CreateAuthor(author) as OkObjectResult;

        //    Assert.Equivalent(HttpStatusCode.OK, result.StatusCode);
        //}

        //[SkippableFact]
        //public void createBook()
        //{
        //    Skip.If(skip);

        //    var builder = new BookOM().CreateBook();
        //    var book = builder.buildDto();

        //    var result = bookController.CreateBook(1, book);

        //    Assert.Equivalent(HttpStatusCode.OK, result);
        //}
    }
}
