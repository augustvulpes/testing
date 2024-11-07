using Allure.Xunit.Attributes;
using LibraryApp.Interfaces.ServiceInterfaces;
using LibraryApp.Interfaces.RepositoryInterfaces;
using Xunit;
using Moq;
using LibraryApp.Models;
using LibraryApp.Services;
using AutoMapper;
using LibraryApp.Helper;
using LibraryApp.Dto;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using LibraryApp.Repository;

namespace LibraryApp.Tests.UnitTests.DataAccess
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Author Repository Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class AuthorRepositoryUnitTests
    {
        [Fact]
        public void PostGetAuthor()
        {
            var builder = new AuthorOM().CreateAuthor();
            var author = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new AuthorRepository(dbContext);

            repository.CreateAuthor(author);

            var createdAuthor = repository.GetAuthor(author.Id);

            Assert.Equivalent(author, createdAuthor);
        }

        [Fact]
        public void DeleteGetAuthor()
        {
            var builder = new AuthorOM().CreateAuthor();
            var author = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new AuthorRepository(dbContext);

            repository.CreateAuthor(author);

            var createdAuthor = repository.GetAuthor(author.Id);

            repository.DeleteAuthor(createdAuthor);

            Assert.Equivalent(author, createdAuthor);
        }
    }
}
