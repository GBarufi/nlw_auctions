using Auctions.API.Entities;

namespace Auctions.API.Contracts
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
