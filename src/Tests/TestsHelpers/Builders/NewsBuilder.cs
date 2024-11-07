using LibraryApp.Dto;
using LibraryApp.Models;

namespace LibraryApp.Tests.TestsHelpers.Builders
{
    public class NewsBuilder
    {
        int Id;
        public string Title;
        public string Description;
        public DateTime CreationDate;

        public NewsBuilder() { }

        public NewsBuilder WithId(int Id)
        {
            this.Id = Id;
            return this;
        }

        public NewsBuilder WithTitle(string Title)
        {
            this.Title = Title;
            return this;
        }

        public NewsBuilder WithDescription(string Description)
        {
            this.Description = Description;
            return this;
        }

        public NewsBuilder WithCreationDate(DateTime CreationDate)
        {
            this.CreationDate = CreationDate;
            return this;
        }

        public News build()
        {
            var news = new News { Id = Id, Title = Title, Description = Description, CreationDate = CreationDate };
            return news;
        }

        public NewsDto buildDto()
        {
            var news = new NewsDto { Id = Id, Title = Title, Description = Description, CreationDate = CreationDate };
            return news;
        }
    }
}
