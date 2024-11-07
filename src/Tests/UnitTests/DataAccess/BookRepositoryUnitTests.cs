using Allure.Xunit.Attributes;
using LibraryApp.Repository;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.UnitTests.DataAccess
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Book Repository Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class BookRepositoryUnitTests
    {
        [Fact]
        public void PostGetBook()
        {
            var builder = new BookOM().CreateBook();
            var book = builder.build();
            var builderAuthor = new AuthorOM().CreateAuthor();
            var author = builderAuthor.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new BookRepository(dbContext);
            var repositoryAuthor = new AuthorRepository(dbContext);

            repositoryAuthor.CreateAuthor(author);
            repository.CreateBook(author.Id, book);

            var createdBook = repository.GetBook(book.Id);

            Assert.Equivalent(book, createdBook);
        }

        [Fact]
        public void DeleteGetBook()
        {
            var builder = new BookOM().CreateBook();
            var book = builder.build();
            var builderAuthor = new AuthorOM().CreateAuthor();
            var author = builderAuthor.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new BookRepository(dbContext);
            var repositoryAuthor = new AuthorRepository(dbContext);

            repositoryAuthor.CreateAuthor(author);
            repository.CreateBook(author.Id, book);

            var createdBook = repository.GetBook(book.Id);

            repository.DeleteBook(createdBook);

            Assert.Equivalent(book, createdBook);
        }
    }
}
