﻿using LibraryApp.Interfaces.ServiceInterfaces;
using LibraryApp.Interfaces.RepositoryInterfaces;
using Xunit;
using Moq;
using LibraryApp.Models;
using LibraryApp.Services;
using AutoMapper;
using LibraryApp.Helper;
using LibraryApp.Dto;
using LibraryApp.Tests.TestsHelpers.ObjectMothers;
using Allure.Xunit.Attributes;

namespace LibraryApp.Tests.UnitTests.Services
{
    [AllureOwner("Maksim Rud")]
    [AllureSuite("Review Service Unit Test")]
    [TestCaseOrderer(
        ordererTypeName: "TestsHelpers.Orderer.RandomOrderer",
        ordererAssemblyName: "TestsHelpers")]
    public class ReviewServiceUnitTests
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
        public readonly Mock<IReviewRepository> _reviewRepositoryMock = new();
        public readonly Mock<IBookRepository> _bookRepositoryMock = new();
        public readonly Mock<IUserRepository> _userRepositoryMock = new();

        public ReviewServiceUnitTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());
            var mapper = config.CreateMapper();

            _reviewService = new ReviewService(_reviewRepositoryMock.Object,
                _userRepositoryMock.Object,
                _bookRepositoryMock.Object,
                mapper);
            _mapper = mapper;
        }

        [Fact]
        public void GetAllReviews()
        {
            //var testReviews = new List<Review>
            //{
            //    new Review { Id = 1, BookId = 1, UserId = "1", Content = "asd", CreationDate = DateTime.Today },
            //    new Review { Id = 2, BookId = 2, UserId = "12", Content = "asd2", CreationDate = DateTime.Today }
            //};
            var builders = new ReviewOM().CreateRange();
            var reviews = builders.Select(r => r.build()).ToList();

            _reviewRepositoryMock.Setup(r => r.GetReviews()).Returns(reviews);

            var resultReviews = _mapper.Map<List<Review>>(_reviewService.GetReviews());

            Assert.Equivalent(reviews, resultReviews);
        }

        [Fact]
        public void GetReview()
        {
            //var testReview = new Review { Id = 1, BookId = 1, UserId = "1", Content = "asd", CreationDate = DateTime.Today };
            var builder = new ReviewOM().CreateReview();
            var review = builder.build();

            _reviewRepositoryMock.Setup(r => r.ReviewExists(It.IsAny<int>())).Returns(true);
            _reviewRepositoryMock.Setup(r => r.GetReview(It.IsAny<int>())).Returns(review);

            var resultReview = _mapper.Map<Review>(_reviewService.GetReview(1));

            Assert.Equivalent(review, resultReview);
        }

        [Fact]
        public void CreateReview()
        {
            //var reviewCreate = new ReviewDto { Id = 1, BookId = 1, UserId = "1", Content = "asd", CreationDate = DateTime.Today };
            //var testBook = new Book { Id = 1, Title = "Qwe", Pages = 128, Year = 2000, BBK = "asd" };
            var testUser = new User { Id = "1" };

            var reviewBuilder = new ReviewOM().CreateReview();
            var review = reviewBuilder.buildDto();
            var bookBuilder = new BookOM().CreateBook();
            var book = bookBuilder.build();

            _bookRepositoryMock.Setup(r => r.GetBook(It.IsAny<int>())).Returns(book);
            _userRepositoryMock.Setup(r => r.GetReviewsByUser(It.IsAny<string>())).Returns(new List<Review> { });
            _userRepositoryMock.Setup(r => r.GetUser(It.IsAny<string>())).Returns(testUser);
            _reviewRepositoryMock.Setup(r => r.CreateReview(It.IsAny<Review>())).Returns(true);

            var result = _reviewService.CreateReview(review);

            Assert.Equivalent("Successfully created", result);
        }

        [Fact]
        public void UpdateReview()
        {
            //var reviewUpdate = new ReviewDto { Id = 1, BookId = 1, UserId = "1", Content = "asd", CreationDate = DateTime.Today };
            var reviewBuilder = new ReviewOM().CreateReview();
            var review = reviewBuilder.buildDto();

            _reviewRepositoryMock.Setup(r => r.ReviewExists(It.IsAny<int>())).Returns(true);
            _reviewRepositoryMock.Setup(r => r.UpdateReview(It.IsAny<Review>())).Returns(true);

            var result = _reviewService.UpdateReview(1, review);

            Assert.Equivalent("Successfully updated", result);
        }

        [Fact]
        public void DeleteReview()
        {
            //var testReview = new Review { Id = 1, BookId = 1, UserId = "1", Content = "asd", CreationDate = DateTime.Today };
            var builder = new ReviewOM().CreateReview();
            var review = builder.build();

            _reviewRepositoryMock.Setup(r => r.GetReview(It.IsAny<int>())).Returns(review);
            _reviewRepositoryMock.Setup(r => r.DeleteReview(review)).Returns(true);

            var result = _reviewService.DeleteReview(1);

            Assert.Equivalent("Successfully deleted", result);
        }
    }
}
