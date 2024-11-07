using Allure.Xunit.Attributes;
using LibraryApp.Repository;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Xunit;

namespace LibraryApp.Tests.UnitTests.DataAccess
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Order Repository Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class OrderRepositoryUnitTests
    {
        [Fact]
        public void PostGetOrder()
        {
            var builder = new OrderOM().CreateOrder();
            var order = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new OrderRepository(dbContext);

            repository.CreateOrder(order);

            var createdOrder = repository.GetOrder(order.Id);

            Assert.Equivalent(order, createdOrder);
        }

        [Fact]
        public void DeleteGetOrder()
        {
            var builder = new OrderOM().CreateOrder();
            var order = builder.build();

            using var dbContext = ContextCreator.CreateContext();
            var repository = new OrderRepository(dbContext);

            repository.CreateOrder(order);

            var createdOrder = repository.GetOrder(order.Id);

            repository.DeleteOrder(createdOrder);

            Assert.Equivalent(order, createdOrder);
        }
    }
}
