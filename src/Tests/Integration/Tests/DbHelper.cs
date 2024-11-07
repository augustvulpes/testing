using LibraryApp.Data;
using LibraryApp.Interfaces.RepositoryInterfaces;
using LibraryApp.Repository;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Tests.Integration.Tests
{
    public class DbHelper
    {
        private readonly static string connectionString = "Server=postgres1; User ID=postgres; Password=adminadmin; Port=5432; Database=library;";

        private readonly static DataContext context = new DataContext(new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connectionString)
                .Options);

        private readonly static IHost host = new HostBuilder().ConfigureServices((hostContext, services) =>
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<AuthorService>()
                .AddScoped<BookService>()
                .AddScoped<CollectionService>()
                .AddScoped<NewsService>()
                .AddScoped<OrderService>()
                .AddScoped<ReviewService>()
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<ICollectionRepository, CollectionRepository>()
                .AddScoped<INewsRepository, NewsRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IReviewRepository, ReviewRepository>()
                .AddSingleton(context);
        }).Build();

        public static void ClearDb()
        {
            context.Authors.RemoveRange(context.Authors);
            context.Books.RemoveRange(context.Books);
            context.Collections.RemoveRange(context.Collections);
            context.News.RemoveRange(context.News);
            context.Orders.RemoveRange(context.Orders);
            context.Reviews.RemoveRange(context.Reviews);
            context.SaveChanges();
        }

        public static T GetRequiredService<T>() where T : notnull
        {
            using var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            return services.GetRequiredService<T>();
        }

        public static DataContext GetContext()
        {
            return context;
        }
    }
}
