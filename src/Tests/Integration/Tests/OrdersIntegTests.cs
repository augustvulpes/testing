using AutoMapper;
using LibraryApp.Data;
using LibraryApp.Dto;
using LibraryApp.Helper;
using LibraryApp.Interfaces.RepositoryInterfaces;
using LibraryApp.Interfaces.ServiceInterfaces;
using LibraryApp.Repository;
using LibraryApp.Services;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryApp.Tests.Integration.Tests
{
    [Collection(nameof(NonParallelCollection))]
    public class OrdersIntegTests
    {
        //private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly bool skip = true;
        private readonly DataContext dbContext;

        private readonly IOrderService _orderService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public readonly IOrderRepository _orderRepository;
        public readonly IBookRepository _bookRepository;
        public readonly IUserRepository _userRepository;
        public readonly IAuthorRepository _authorRepository;
        public readonly ICollectionRepository _collectionRepository;

        public OrdersIntegTests()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());
            var mapper = mapperConfig.CreateMapper();

            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();

            _orderRepository = new OrderRepository(dbContext);
            _bookRepository = new BookRepository(dbContext);
            _userRepository = new UserRepository(dbContext);
            _authorRepository = new AuthorRepository(dbContext);
            _collectionRepository = new CollectionRepository(dbContext);
            _mapper = mapper;

            _bookService = new BookService(_bookRepository,
                _authorRepository,
                _collectionRepository,
                _mapper);
            _userService = new UserService(_userRepository, mapper, null, null);
            _orderService = new OrderService(_orderRepository,
                _userRepository,
                _bookRepository,
                _mapper);
        }

        ~OrdersIntegTests()
        {
            DbHelper.ClearDb();
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(skip);

            var builder = new OrderOM().CreateOrder();
            var order = builder.buildDto();

            var bookBuilder = new BookOM().CreateBook();
            var book = bookBuilder.build();

            var userBuilder = new UserOM().CreateUser();
            var user = userBuilder.build();

            dbContext.Books.Add(book);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var result = _orderService.CreateOrder(order);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", result);
        }

        [SkippableFact]
        public void GetOrder()
        {
            Skip.If(skip);
            var builders = new OrderOM().CreateRange();
            var orders = builders.Select(or => or.buildDto()).ToList();

            var bookBuilder = new BookOM().CreateBook();
            var book = bookBuilder.build();

            var userBuilder = new UserOM().CreateUser();
            var user = userBuilder.build();

            dbContext.Books.Add(book);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            //var orders = new List<OrderDto> { testOrder1, testOrder2 };

            //_orderService.CreateOrder(orders[0]);
            _orderService.CreateOrder(orders[1]);

            var resultOrders = _orderService.GetAllOrders();

            //_orderService.DeleteOrder(testOrder1.Id);
            //_orderService.DeleteOrder(testOrder2.Id);

            Assert.Equivalent(orders[1], resultOrders[0]);
        }
    }
}
