using LibraryApp.Data;
using LibraryApp.Interfaces.RepositoryInterfaces;
using LibraryApp.Repository;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Tests.Integration.Tests
{
    public class DbHelper
    {
        // Для деплоя в контейнер и CD/CD
        private readonly static string connectionString = "Server=postgres; Database=library; User ID=postgres; Password=adminadmin";
        // Для локального запуска
        //private readonly static string connectionString = "Host=localhost; Database=library; Username=postgres; Password=adminadmin";

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
            context.Users.RemoveRange(context.Users);
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
