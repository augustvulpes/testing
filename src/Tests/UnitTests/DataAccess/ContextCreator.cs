using LibraryApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryApp.Tests.UnitTests.DataAccess
{
    public class ContextCreator
    {
        public static DataContext CreateContext()
        {
            var name = "database_" + Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;

            var context = new DataContext(options);
            return context;
        }
    }
}
