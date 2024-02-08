using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.UseCases.Auctions
{
    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionRepository _repository;
        public GetCurrentAuctionUseCase(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public Auction? Execute() => _repository.GetCurrent();
    }
}
