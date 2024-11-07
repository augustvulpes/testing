using LibraryApp.Dto;
using LibraryApp.Models;

namespace LibraryApp.Tests.TestsHelpers.Builders
{
    public class AuthorBuilder
    {
        public int Id;
        public string Country;
        public string Name;

        public AuthorBuilder() { }

        public AuthorBuilder withId(int Id)
        {
            this.Id = Id;
            return this;
        }

        public AuthorBuilder withCountry(string Country)
        {
            this.Country = Country;
            return this;
        }

        public AuthorBuilder withName(string Name)
        {
            this.Name = Name;
            return this;
        }

        public Author build()
        {
            return new Author { Id = Id, Country = Country, Name = Name };
        }

        public AuthorDto buildDto()
        {
            return new AuthorDto { Id = Id, Country = Country, Name = Name };
        }
    }
}
