using Auctions.API.Communication.Requests;
using Auctions.API.Filters;
using Auctions.API.UseCases.Offers;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.API.Controllers
{
    [ApiController]
    public class OfferController : BaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        [ServiceFilter(typeof(AuthenticationUserAttribute))]
        public IActionResult CreateOffer(
            [FromRoute] int itemId, 
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
        {
            var offerId = useCase.Execute(itemId, request);
            return Created(string.Empty, offerId);
        }
    }
}
