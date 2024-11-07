using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
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

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(skip);

            var builder = new AuthorOM().CreateAuthor();
            var author = builder.buildDto();

            var authorsService = DbHelper.GetRequiredService<AuthorService>();
            var result = authorsService.CreateAuthor(author);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", result);
        }

        //[SkippableFact]
        //public void UpdateAuthor()
        //{
        //    Skip.If(skip);

        //    var builder = new AuthorOM().CreateAuthor();
        //    var author = builder.build();
        //    var editedAuthor = builder.withName("Test Name").build();

        //    dbContext.Authors.Add(author);
        //    dbContext.SaveChanges();

        //    var authorsService = DbHelper.GetRequiredService<AuthorService>();
        //    author.Name = "New Name";
        //    dbContext.Update(author);
        //    DbHelper.ClearDb();

        //    //Assert.Equivalent("Successfully updated", result);
        //}
    }
}
