using LibraryApp.Tests.TestsHelpers.Builders;

namespace LibraryApp.Tests.TestsHelpers.ObjectMothers
{
    public class OrderOM
    {
        public OrderBuilder CreateOrder()
        {
            return new OrderBuilder()
                    .WithId(1)
                    .WithBookId(1)
                    .WithUserId("1")
                    .WithState("new")
                    .WithCreationDate(DateTime.UtcNow);
        }

        public List<OrderBuilder> CreateRange()
        {
            return new List<OrderBuilder>
            {
                new OrderBuilder()
                    .WithId(1)
                    .WithBookId(1)
                    .WithUserId("1")
                    .WithState("new")
                    .WithCreationDate(DateTime.UtcNow),
                new OrderBuilder()
                    .WithId(2)
                    .WithBookId(1)
                    .WithUserId("1")
                    .WithState("new")
                    .WithCreationDate(DateTime.UtcNow)
            };
        }
    }
}
