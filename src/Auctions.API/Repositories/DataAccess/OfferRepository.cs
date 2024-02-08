using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AuctionsDbContext _dbContext;

        public OfferRepository(AuctionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }
    }
}
