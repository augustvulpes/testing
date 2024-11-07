using Allure.Xunit.Attributes;
using LibraryApp.Repository;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.UnitTests.DataAccess
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Review Repository Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class ReviewRepositoryUnitTests
    {
        [Fact]
        public void PostGetReview()
        {
            var builder = new ReviewOM().CreateReview();
            var review = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new ReviewRepository(dbContext);

            repository.CreateReview(review);

            var createdReview = repository.GetReview(review.Id);

            Assert.Equivalent(review, createdReview);
        }

        [Fact]
        public void DeleteGetReview()
        {
            var builder = new ReviewOM().CreateReview();
            var review = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new ReviewRepository(dbContext);

            repository.CreateReview(review);

            var createdReview = repository.GetReview(review.Id);

            repository.DeleteReview(createdReview);

            Assert.Equivalent(review, createdReview);
        }
    }
}
