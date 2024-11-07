using Allure.Xunit.Attributes;
using LibraryApp.Repository;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.UnitTests.DataAccess
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("News Repository Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class NewsRepositoryUnitTests
    {
        [Fact]
        public void PostGetNews()
        {
            var builder = new NewsOM().CreateNews();
            var news = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new NewsRepository(dbContext);

            repository.CreateNews(news);

            var createdNews = repository.GetNewsById(news.Id);

            Assert.Equivalent(news, createdNews);
        }

        [Fact]
        public void DeleteGetNews()
        {
            var builder = new NewsOM().CreateNews();
            var news = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new NewsRepository(dbContext);

            repository.CreateNews(news);

            var createdNews = repository.GetNewsById(news.Id);

            repository.DeleteNews(createdNews);

            Assert.Equivalent(news, createdNews);
        }
    }
}
