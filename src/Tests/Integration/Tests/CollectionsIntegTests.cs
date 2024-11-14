using Allure.Xunit.Attributes;
using LibraryApp.Data;
using LibraryApp.Dto;
using LibraryApp.Interfaces.ServiceInterfaces;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Collections Service Integ Test")]
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

        ~CollectionsIntegTests()
        {
            DbHelper.ClearDb();
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(Environment.GetEnvironmentVariable("skip") == "true");

            var builder = new CollectionOM().CreateCollection();
            var collection = builder.buildDto();

            var collectionsService = DbHelper.GetRequiredService<CollectionService>();
            var result = collectionsService.CreateCollection(collection);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", result);
        }

        [SkippableFact]
        public void GetCollections()
        {
            Skip.If(Environment.GetEnvironmentVariable("skip") == "true");
            //var testCollection1 = new CollectionDto { Id = 9990, Title = "TEST1", CreationDate = DateTime.UtcNow, Description = "TEST" };
            //var testCollection2 = new CollectionDto { Id = 9991, Title = "TEST2", CreationDate = DateTime.UtcNow, Description = "TEST" };
            var builders = new CollectionOM().CreateRange();
            var collections = builders.Select(c => c.buildDto()).ToList();

            //var collections = new List<CollectionDto> { testCollection1, testCollection2 };
            //_collectionService.CreateCollection(testCollection1);
            //_collectionService.CreateCollection(testCollection2);
            var collectionsService = DbHelper.GetRequiredService<CollectionService>();
            collectionsService.CreateCollection(collections[0]);
            collectionsService.CreateCollection(collections[1]);

            var resultCollections = collectionsService.GetCollections();

            //_collectionService.DeleteCollection(testCollection1.Id);
            //_collectionService.DeleteCollection(testCollection2.Id);
            DbHelper.ClearDb();

            Assert.Equivalent(collections, resultCollections);
        }
    }
}
