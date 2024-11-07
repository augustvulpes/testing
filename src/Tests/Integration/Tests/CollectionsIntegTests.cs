using LibraryApp.Data;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    public class CollectionsIntegTests
    {
        private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly DataContext dbContext;

        public CollectionsIntegTests()
        {
            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();
        }

        //[SkippableFact]
        //public void TestAdd()
        //{
        //    Skip.If(skip);

        //}
    }
}
