using LibraryApp.Tests.TestsHelpers.Builders;

namespace LibraryApp.Tests.TestsHelpers.ObjectMothers
{
    public class CollectionOM
    {
        public CollectionBuilder CreateCollection()
        {
            return new CollectionBuilder()
                .WithId(1)
                .WithTitle("Collection One")
                .WithDescription("Decent collection")
                .WithCreationDate(DateTime.Today);
        }

        public List<CollectionBuilder> CreateRange()
        {
            return new List<CollectionBuilder>
            {
                new CollectionBuilder()
                    .WithId(1)
                    .WithTitle("Collection One")
                    .WithDescription("Decent collection")
                    .WithCreationDate(DateTime.Today),
                new CollectionBuilder()
                    .WithId(2)
                    .WithTitle("Collection Two")
                    .WithDescription("Another decent collection")
                    .WithCreationDate(DateTime.Today)
            };
        }
    }
}
