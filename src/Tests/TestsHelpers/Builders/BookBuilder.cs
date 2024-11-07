using LibraryApp.Dto;
using LibraryApp.Models;
using Microsoft.VisualBasic;

namespace LibraryApp.Tests.TestsHelpers.Builders
{
    public class BookBuilder
    {
        public int Id;
        public string Title;
        public int Pages;
        public int Year;
        public string BBK;

        public BookBuilder() { }

        public BookBuilder WithId(int Id)
        {
            this.Id = Id;
            return this;
        }

        public BookBuilder WithTitle(string Title)
        {
            this.Title = Title;
            return this;
        }

        public BookBuilder WithPages(int Pages)
        {
            this.Pages = Pages;
            return this;
        }

        public BookBuilder WithYear(int Year)
        {
            this.Year = Year;
            return this;
        }

        public BookBuilder WithBBK(string BBK)
        {
            this.BBK = BBK;
            return this;
        }

        public Book build()
        {
            var book = new Book { Id=Id, Title=Title, Pages = Pages, Year = Year, BBK = BBK };
            return book;
        }

        public BookDto buildDto()
        {
            var book = new BookDto { Id = Id, Title = Title, Pages = Pages, Year = Year, BBK = BBK };
            return book;
        }
    }
}
