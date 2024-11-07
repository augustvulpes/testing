using Allure.Xunit.Attributes;
using LibraryApp.Repository;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.UnitTests.DataAccess
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Collection Repository Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class CollectionRepositoryUnitTests
    {
        [Fact]
        public void PostGetCollection()
        {
            var builder = new CollectionOM().CreateCollection();
            var collection = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new CollectionRepository(dbContext);

            repository.CreateCollection(collection);

            var createdCollection = repository.GetCollection(collection.Id);

            Assert.Equivalent(collection, createdCollection);
        }

        [Fact]
        public void DeleteGetCollection()
        {
            var builder = new CollectionOM().CreateCollection();
            var collection = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new CollectionRepository(dbContext);

            repository.CreateCollection(collection);

            var createdCollection = repository.GetCollection(collection.Id);

            repository.DeleteCollection(createdCollection);

            Assert.Equivalent(collection, createdCollection);
        }
    }
}
