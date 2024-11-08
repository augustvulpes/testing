﻿using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [Collection(nameof(NonParallelCollection))]
    public class CollectionsIntegTests
    {
        private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly DataContext dbContext;

        public CollectionsIntegTests()
        {
            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(skip);

            var builder = new CollectionOM().CreateCollection();
            var collection = builder.buildDto();

            var collectionsService = DbHelper.GetRequiredService<CollectionService>();
            var result = collectionsService.CreateCollection(collection);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", result);
        }
    }
}
