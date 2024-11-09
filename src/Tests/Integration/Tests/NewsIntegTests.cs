using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [Collection(nameof(NonParallelCollection))]
    public class NewsIntegTests
    {
        //private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly bool skip = true;
        private readonly DataContext dbContext;

        public NewsIntegTests()
        {
            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();
        }

        ~NewsIntegTests()
        {
            DbHelper.ClearDb();
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(skip);

            var builder = new NewsOM().CreateNews();
            var news = builder.buildDto();

            var newsService = DbHelper.GetRequiredService<NewsService>();
            var result = newsService.CreateNews(news);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", result);
        }

        [SkippableFact]
        public void GetNews()
        {
            Skip.If(skip);
            var builders = new NewsOM().CreateRange();
            var news = builders.Select(n => n.buildDto()).ToList();

            var newsService = DbHelper.GetRequiredService<NewsService>();
            newsService.CreateNews(news[0]);
            newsService.CreateNews(news[1]);

            var resultNews = newsService.GetNews();

            DbHelper.ClearDb();

            Assert.Equivalent(news, resultNews);
        }
    }
}
