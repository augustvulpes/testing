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
using Allure.Xunit.Attributes;

namespace LibraryApp.Tests.UnitTests.Services
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("News Service Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class NewsServiceUnitTests
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        public readonly Mock<INewsRepository> _newsRepositoryMock = new();

        public NewsServiceUnitTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());
            var mapper = config.CreateMapper();

            _newsService = new NewsService(_newsRepositoryMock.Object, mapper);
            _mapper = mapper;
        }

        [Fact]
        public void GetNews()
        {
            //var testNews = new List<News>
            //{
            //    new News { Id = 1, Description = "test", Title = "Abc", CreationDate = DateTime.Today },
            //    new News { Id = 2, Description = "test2", Title = "Abc2", CreationDate = DateTime.Today }
            //};
            var builders = new NewsOM().CreateRange();
            var news = builders.Select(n => n.build()).ToList();

            _newsRepositoryMock.Setup(r => r.GetNews()).Returns(news);

            var resultNews = _mapper.Map<List<News>>(_newsService.GetNews());

            Assert.Equivalent(news, resultNews);
        }

        [Fact]
        public void GetNewsById()
        {
            //var testNews = new News { Id = 1, Description = "test", Title = "Abc", CreationDate = DateTime.Today };
            var builder = new NewsOM().CreateNews();
            var news = builder.build();

            _newsRepositoryMock.Setup(r => r.NewsExists(It.IsAny<int>())).Returns(true);
            _newsRepositoryMock.Setup(r => r.GetNewsById(It.IsAny<int>())).Returns(news);

            var resultNews = _mapper.Map<News>(_newsService.GetNewsById(1));

            Assert.Equivalent(news, resultNews);
        }

        [Fact]
        public void CreateNews()
        {
            //var newsCreate = new NewsDto { Id = 1, Description = "test", Title = "Abc", CreationDate = DateTime.Today };
            var builder = new NewsOM().CreateNews();
            var news = builder.buildDto();

            _newsRepositoryMock.Setup(r => r.GetNews()).Returns(new List<News> { });
            _newsRepositoryMock.Setup(r => r.CreateNews(It.IsAny<News>())).Returns(true);

            var result = _newsService.CreateNews(news);

            Assert.Equivalent("Successfully created", result);
        }

        [Fact]
        public void UpdateNews()
        {
            //var newsUpdate = new NewsDto { Id = 1, Description = "test", Title = "Abc", CreationDate = DateTime.Today };
            var builder = new NewsOM().CreateNews();
            var news = builder.buildDto();

            _newsRepositoryMock.Setup(r => r.NewsExists(It.IsAny<int>())).Returns(true);
            _newsRepositoryMock.Setup(r => r.UpdateNews(It.IsAny<News>())).Returns(true);

            var result = _newsService.UpdateNews(1, news);

            Assert.Equivalent("Successfully updated", result);
        }

        [Fact]
        public void DeleteNews()
        {
            //var testNews = new News { Id = 1, Description = "test", Title = "Abc", CreationDate = DateTime.Today };
            var builder = new NewsOM().CreateNews();
            var news = builder.build();

            _newsRepositoryMock.Setup(r => r.GetNewsById(It.IsAny<int>())).Returns(news);
            _newsRepositoryMock.Setup(r => r.DeleteNews(news)).Returns(true);

            var result = _newsService.DeleteNews(1);

            Assert.Equivalent("Successfully deleted", result);
        }
    }
}
