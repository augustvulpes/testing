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

namespace LibraryApp.Tests.UnitTests.Services
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Author Service Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class AuthorServiceUnitTests
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public readonly Mock<IAuthorRepository> _authorRepositoryMock = new();

        public AuthorServiceUnitTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());
            var mapper = config.CreateMapper();

            _authorService = new AuthorService(_authorRepositoryMock.Object, mapper);
            _mapper = mapper;
        }

        [Fact]
        public void GetAuthors()
        {
            //var testauthors = new list<author>
            //{
            //    new author { id = 1, country = "russia", name = "a. s. pushkin" },
            //    new author { id = 2, country = "russia", name = "l. n. tolstoy" },
            //};
            var builders = new AuthorOM().CreateRange();
            var authors = builders.Select(a => a.build()).ToList();

            _authorRepositoryMock.Setup(r => r.GetAuthors()).Returns(authors);

            var resultAuthors = _mapper.Map<List<Author>>(_authorService.GetAuthors());

            Environment.SetEnvironmentVariable("skip", "true");
            Assert.Equivalent(authors, resultAuthors);
            // ФЕЙЛИМСЯ СПЕЦИАЛЬНО
            Assert.Equivalent(authors, builders);
            Environment.SetEnvironmentVariable("skip", "false");
        }

        [Fact]
        public void GetAuthor()
        {
            //var testAuthor = new Author { Id = 1, Country = "Russia", Name = "A. S. Pushkin" };
            var builder = new AuthorOM().CreateAuthor();
            var author = builder.build();

            _authorRepositoryMock.Setup(r => r.AuthorExists(It.IsAny<int>())).Returns(true);
            _authorRepositoryMock.Setup(r => r.GetAuthor(It.IsAny<int>())).Returns(author);

            var resultAuthor = _mapper.Map<Author>(_authorService.GetAuthor(1));

            Assert.Equivalent(author, resultAuthor);
        }

        [Fact]
        public void GetBooksByAuthorId()
        {
            //var testBooks = new List<Book>
            //{
            //    new Book { Id = 1, Title = "Abc", Pages = 128, Year = 2000, BBK = "asd" }
            //};
            var builders = new BookOM().CreateRange();
            var books = builders.Select(b => b.build()).ToList();

            _authorRepositoryMock.Setup(r => r.GetBooksByAuthor(It.IsAny<int>())).Returns(books);

            var resultBooks = _mapper.Map<List<Book>>(_authorService.GetBooksByAuthorId(1));

            Assert.Equivalent(books, resultBooks);
        }

        [Fact]
        public void CreateAuthor()
        {
            //var authorCreate = new AuthorDto { Id = 1, Country = "Russia", Name = "A. S. Pushkin" };
            var builder = new AuthorOM().CreateAuthor();
            var author = builder.buildDto();

            _authorRepositoryMock.Setup(r => r.GetAuthors()).Returns(new List<Author> { });
            _authorRepositoryMock.Setup(r => r.CreateAuthor(It.IsAny<Author>())).Returns(true);

            var result = _authorService.CreateAuthor(author);

            Assert.Equivalent("Successfully created", result);
        }

        [Fact]
        public void UpdateAuthor()
        {
            //var authorUpdate = new AuthorDto { Id = 1, Country = "Russia", Name = "A. S. Pushkin" };
            var builder = new AuthorOM().CreateAuthor();
            var author = builder.buildDto();

            _authorRepositoryMock.Setup(r => r.AuthorExists(It.IsAny<int>())).Returns(true);
            _authorRepositoryMock.Setup(r => r.UpdateAuthor(It.IsAny<Author>())).Returns(true);

            var result = _authorService.UpdateAuthor(1, author);

            Assert.Equivalent("Successfully updated", result);
        }

        [Fact]
        public void DeleteAuthor()
        {
            //var testAuthor = new Author { Id = 1, Country = "Russia", Name = "A. S. Pushkin" };
            var builder = new AuthorOM().CreateAuthor();
            var author = builder.build();

            _authorRepositoryMock.Setup(r => r.GetAuthor(It.IsAny<int>())).Returns(author);
            _authorRepositoryMock.Setup(r => r.DeleteAuthor(author)).Returns(true);

            var result = _authorService.DeleteAuthor(1);

            Assert.Equivalent("Successfully deleted", result);
        }
    }
}
//allure serve allure-results