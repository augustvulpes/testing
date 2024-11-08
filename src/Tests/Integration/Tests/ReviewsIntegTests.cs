using AutoMapper;
using LibraryApp.Data;
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
    public class ReviewsIntegTests
    {
        private readonly bool skip = Environment.GetEnvironmentVariable("skip") == "true";
        private readonly DataContext dbContext;

        private readonly IReviewService _reviewService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public readonly IReviewRepository _reviewRepository;
        public readonly IBookRepository _bookRepository;
        public readonly IUserRepository _userRepository;
        public readonly IAuthorRepository _authorRepository;
        public readonly ICollectionRepository _collectionRepository;

        public ReviewsIntegTests()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());
            var mapper = mapperConfig.CreateMapper();

            dbContext = DbHelper.GetContext();
            DbHelper.ClearDb();

            _reviewRepository = new ReviewRepository(dbContext);
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
            _reviewService = new ReviewService(_reviewRepository,
                _userRepository,
                _bookRepository,
                _mapper);
        }

        [SkippableFact]
        public void TestAdd()
        {
            Skip.If(skip);

            var builder = new ReviewOM().CreateReview();
            var review = builder.buildDto();

            var bookBuilder = new BookOM().CreateBook();
            var book = bookBuilder.build();

            var userBuilder = new UserOM().CreateUser();
            var user = userBuilder.build();

            dbContext.Books.Add(book);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var result = _reviewService.CreateReview(review);

            DbHelper.ClearDb();

            Assert.Equivalent("Successfully created", result);
        }
    }
}
