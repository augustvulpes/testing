using LibraryApp.Dto;
using LibraryApp.Models;

namespace LibraryApp.Tests.TestsHelpers.Builders
{
    public class OrderBuilder
    {
        public int Id;
        public int BookId;
        public string UserId;
        public string State;
        public DateTime CreationDate;

        public OrderBuilder() { }

        public OrderBuilder WithId(int Id)
        {
            this.Id = Id;
            return this;
        }

        public OrderBuilder WithBookId(int BookId)
        {
            this.BookId = BookId;
            return this;
        }

        public OrderBuilder WithUserId(string UserId)
        {
            this.UserId = UserId;
            return this;
        }

        public OrderBuilder WithState(string State)
        {
            this.State = State;
            return this;
        }

        public OrderBuilder WithCreationDate(DateTime CreationDate)
        {
            this.CreationDate = CreationDate;
            return this;
        }

        public Order build()
        {
            var order = new Order { Id=Id, BookId=BookId, UserId=UserId, State=State, CreationDate=CreationDate };
            return order;
        }

        public OrderDto buildDto()
        {
            var order = new OrderDto { Id = Id, BookId = BookId, UserId = UserId, State = State, CreationDate = CreationDate };
            return order;
        }
    }
}
