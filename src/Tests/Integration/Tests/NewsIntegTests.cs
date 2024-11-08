using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [Collection(nameof(NonParallelCollection))]
    public class NewsIntegTests
    {
        private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly DataContext dbContext;

        public NewsIntegTests()
        {
            dbContext = DbHelper.GetContext();
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
    }
}
