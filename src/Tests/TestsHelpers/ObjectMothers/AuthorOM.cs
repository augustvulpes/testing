using LibraryApp.Tests.TestsHelpers.Builders;

namespace LibraryApp.Tests.TestsHelpers.ObjectMothers
{
    public class AuthorOM
    {
        public AuthorBuilder CreateAuthor()
        {
            return new AuthorBuilder()
                .withId(1)
                .withCountry("Russian Federation")
                .withName("A. S. Pushkin");
        }

        public List<AuthorBuilder> CreateRange()
        {
            return new List<AuthorBuilder>
            {
                new AuthorBuilder()
                    .withId(1)
                    .withCountry("Russian Federation")
                    .withName("A. S. Pushkin"),
                new AuthorBuilder()
                    .withId(2)
                    .withCountry("Russian Federation")
                    .withName("L. N. Tolstoy"),
            };
        }
    }
}
