using Auctions.API.Communication.Requests;
using Auctions.API.Contracts;
using Auctions.API.Entities;
using Auctions.API.Services;

namespace Auctions.API.UseCases.Offers
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _repository;

        public CreateOfferUseCase(IOfferRepository repository, ILoggedUser loggedUser)
        {
            _repository = repository;
            _loggedUser = loggedUser;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var loggedUser = _loggedUser.User();
            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = loggedUser.Id
            };

            _repository.Add(offer);

            return offer.Id;
        }
    }
}
