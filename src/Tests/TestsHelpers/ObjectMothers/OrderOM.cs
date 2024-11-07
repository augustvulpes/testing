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
                    .WithCreationDate(DateTime.Today);
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
                    .WithCreationDate(DateTime.Today),
                new OrderBuilder()
                    .WithId(2)
                    .WithBookId(2)
                    .WithUserId("2")
                    .WithState("new")
                    .WithCreationDate(DateTime.Today)
            };
        }
    }
}
