using LibraryApp.Tests.TestsHelpers.Builders;

namespace LibraryApp.Tests.TestsHelpers.ObjectMothers
{
    public class BookOM
    {
        public BookBuilder CreateBook()
        {
            return new BookBuilder()
                .WithId(1)
                .WithTitle("Test Book One")
                .WithPages(42)
                .WithYear(2000)
                .WithBBK("testBBK");
        }

        public List<BookBuilder> CreateRange()
        {
            return new List<BookBuilder>
            {
                new BookBuilder()
                    .WithId(1)
                    .WithTitle("Test Book One")
                    .WithPages(42)
                    .WithYear(2000)
                    .WithBBK("testBBK"),
                new BookBuilder()
                    .WithId(2)
                    .WithTitle("Test Book Two")
                    .WithPages(24)
                    .WithYear(2002)
                    .WithBBK("testBBK"),
            };
        }
    }
}
