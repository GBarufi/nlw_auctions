using Auctions.API.Entities;
using Auctions.API.UseCases.Auctions;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.API.Controllers
{
    [ApiController]
    public class AuctionController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
        {
            var result = useCase.Execute();

            if (result is null)
                return NoContent();

            return Ok(result);
        }
    }
}
