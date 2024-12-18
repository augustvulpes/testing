﻿using Allure.Xunit.Attributes;
using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("News Service Integ Test")]
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

        ~NewsIntegTests()
        {
            DbHelper.ClearDb();
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(Environment.GetEnvironmentVariable("skip") == "true");

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
            Skip.If(Environment.GetEnvironmentVariable("skip") == "true");
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
