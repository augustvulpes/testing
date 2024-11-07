using LibraryApp.Dto;
using LibraryApp.Models;

namespace LibraryApp.Tests.TestsHelpers.Builders
{
    public class CollectionBuilder
    {
        int Id;
        public string Title;
        public string Description;
        public DateTime CreationDate;

        public CollectionBuilder() { }

        public CollectionBuilder WithId(int Id)
        {
            this.Id = Id;
            return this;
        }

        public CollectionBuilder WithTitle(string Title)
        {
            this.Title = Title;
            return this;
        }

        public CollectionBuilder WithDescription(string Description)
        {
            this.Description = Description;
            return this;
        }

        public CollectionBuilder WithCreationDate(DateTime CreationDate)
        {
            this.CreationDate = CreationDate;
            return this;
        }

        public Collection build()
        {
            var collection = new Collection { Id = Id, Title = Title, Description = Description, CreationDate = CreationDate };
            return collection;
        }

        public CollectionDto buildDto()
        {
            var collection = new CollectionDto { Id = Id, Title = Title, Description = Description, CreationDate = CreationDate };
            return collection;
        }
    }
}
