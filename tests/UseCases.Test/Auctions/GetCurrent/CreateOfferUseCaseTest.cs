using Auctions.API.Communication.Requests;
using Auctions.API.Contracts;
using Auctions.API.Entities;
using Auctions.API.Services;
using Auctions.API.UseCases.Offers;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class CreateOfferUseCaseTest
    {
        private readonly Mock<IOfferRepository> _repositoryMock;
        private readonly Mock<ILoggedUser> _loggedUserMock;

        public CreateOfferUseCaseTest()
        {
            _repositoryMock = new Mock<IOfferRepository>();
            _loggedUserMock = new Mock<ILoggedUser>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Execute_Success(int itemId)
        {
            //Arrange
            var offerRequest = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 100))
                .Generate();

            _loggedUserMock.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(_repositoryMock.Object, _loggedUserMock.Object);

            //Act
            var act = () => useCase.Execute(itemId, offerRequest);

            //Assert
            act.Should().NotThrow();
        }
    }
}
