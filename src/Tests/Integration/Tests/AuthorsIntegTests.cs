using Allure.Xunit.Attributes;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Author Service Integ Test")]
    [Collection(nameof(NonParallelCollection))]
    public class AuthorsIntegTests
    {
        private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly DataContext dbContext;

        public AuthorsIntegTests()
        {
            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();
        }

        ~AuthorsIntegTests()
        {
            DbHelper.ClearDb();
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(Environment.GetEnvironmentVariable("skip") == "true");

            var builder = new AuthorOM().CreateAuthor();
            var author = builder.buildDto();

            var authorsService = DbHelper.GetRequiredService<AuthorService>();
            var result = authorsService.CreateAuthor(author);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", result);
        }

        [SkippableFact]
        public void GetAuthors()
        {
            Skip.If(Environment.GetEnvironmentVariable("skip") == "true");
            //var testAuthor1 = new AuthorDto { Id = 1001, Country = "TEST1001", Name = "TEST1001" };
            //var testAuthor2 = new AuthorDto { Id = 1002, Country = "TEST1002", Name = "TEST1002" };

            var builders = new AuthorOM().CreateRange();
            var authors = builders.Select(a => a.buildDto()).ToList();

            // var authors = new List<AuthorDto> { testAuthor1, testAuthor2 };

            //_authorService.CreateAuthor(testAuthor1);
            //_authorService.CreateAuthor(testAuthor2);

            var authorsService = DbHelper.GetRequiredService<AuthorService>();
            authorsService.CreateAuthor(authors[0]);
            authorsService.CreateAuthor(authors[1]);

            var resultAuthors = authorsService.GetAuthors();

            DbHelper.ClearDb();

            Assert.Equivalent(authors, resultAuthors);
        }

        //[SkippableFact]
        //public void GetAuthor()
        //{
        //    Skip.If(skip);

        //    var builder = new AuthorOM().CreateAuthor();
        //    var author = builder.build();
        //    var editedAuthor = builder.withName("Test Name").build();

        //    dbContext.Authors.Add(author);
        //    dbContext.SaveChanges();

        //    var authorsService = DbHelper.GetRequiredService<AuthorService>();
        //    author.Name = "New Name";
        //    DbHelper.ClearDb();

        //    //Assert.Equivalent("Successfully updated", result);
        //}
    }
}
