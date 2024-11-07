using LibraryApp.Dto;
using LibraryApp.Models;

namespace LibraryApp.Tests.TestsHelpers.Builders
{
    public class ReviewBuilder
    {
        public int Id;
        public int BookId;
        public string UserId;
        public string Content;
        public DateTime CreationDate;

        public ReviewBuilder() { }

        public ReviewBuilder WithId(int Id)
        {
            this.Id = Id;
            return this;
        }

        public ReviewBuilder WithBookId(int BookId)
        {
            this.BookId = BookId;
            return this;
        }

        public ReviewBuilder WithUserId(string UserId)
        {
            this.UserId = UserId;
            return this;
        }

        public ReviewBuilder WithContent(string Content)
        {
            this.Content = Content;
            return this;
        }

        public ReviewBuilder WithCreationDate(DateTime CreationDate)
        {
            this.CreationDate = CreationDate;
            return this;
        }

        public Review build()
        {
            var review = new Review { Id = Id, BookId = BookId, UserId = UserId, Content = Content, CreationDate = CreationDate };
            return review;
        }

        public ReviewDto buildDto()
        {
            var review = new ReviewDto { Id = Id, BookId = BookId, UserId = UserId, Content = Content, CreationDate = CreationDate };
            return review;
        }
    }
}
