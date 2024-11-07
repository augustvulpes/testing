using LibraryApp.Tests.TestsHelpers.Builders;

namespace LibraryApp.Tests.TestsHelpers.ObjectMothers
{
    public class NewsOM
    {
        public NewsBuilder CreateNews()
        {
            return new NewsBuilder()
                .WithId(1)
                .WithTitle("News One")
                .WithDescription("Good news")
                .WithCreationDate(DateTime.Today);
        }

        public List<NewsBuilder> CreateRange()
        {
            return new List<NewsBuilder>
            {
                new NewsBuilder()
                    .WithId(1)
                    .WithTitle("News One")
                    .WithDescription("Good news")
                    .WithCreationDate(DateTime.Today),
                new NewsBuilder()
                    .WithId(2)
                    .WithTitle("News Two")
                    .WithDescription("Another good news")
                    .WithCreationDate(DateTime.Today)
            };
        }
    }
}
