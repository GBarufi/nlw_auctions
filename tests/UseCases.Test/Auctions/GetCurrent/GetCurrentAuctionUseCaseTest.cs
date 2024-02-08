using Auctions.API.Contracts;
using Auctions.API.Entities;
using Auctions.API.Enums;
using Auctions.API.UseCases.Auctions;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        private readonly Mock<IAuctionRepository> _repositoryMock;

        public GetCurrentAuctionUseCaseTest()
        {
            _repositoryMock = new Mock<IAuctionRepository>();
        }

        [Fact]
        public void Execute_Success()
        {
            //Arrange
            var auction = new Faker<Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1, 100))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<AuctionItem>
                {
                    new AuctionItem
                    {
                        Id = f.Random.Number(1, 100),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(50, 1000),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            _repositoryMock.Setup(i => i.GetCurrent()).Returns(auction);
            var useCase = new GetCurrentAuctionUseCase(_repositoryMock.Object);

            //Act
            var result = useCase.Execute();

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(auction.Id);
            result!.Name.Should().Be(auction.Name);
        }
    }
}
