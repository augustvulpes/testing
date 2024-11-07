using LibraryApp.Tests.TestsHelpers.Builders;

namespace LibraryApp.Tests.TestsHelpers.ObjectMothers
{
    public class ReviewOM
    {
        public ReviewBuilder CreateReview()
        {
            return new ReviewBuilder()
                .WithId(1)
                .WithBookId(1)
                .WithUserId("1")
                .WithContent("Review content one")
                .WithCreationDate(DateTime.Today);
        }

        public List<ReviewBuilder> CreateRange()
        {
            return new List<ReviewBuilder>
            {
                new ReviewBuilder()
                    .WithId(1)
                    .WithBookId(1)
                    .WithUserId("1")
                    .WithContent("Review content one")
                    .WithCreationDate(DateTime.Today),
                new ReviewBuilder()
                    .WithId(2)
                    .WithBookId(2)
                    .WithUserId("2")
                    .WithContent("Review content two")
                    .WithCreationDate(DateTime.Today)
            };
        }
    }
}
