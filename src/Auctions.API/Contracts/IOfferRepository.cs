using Auctions.API.Entities;

namespace Auctions.API.Contracts
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
    }
}
