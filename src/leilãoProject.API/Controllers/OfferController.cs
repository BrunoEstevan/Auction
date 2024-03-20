using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Filters;
using AuctionProject.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace AuctionProject.API.Controllers;

public class OfferController : AuctionProjectBaseController
{
    [HttpPost]
    [Route("{itemID}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult CreateOffer(
        [FromRoute]int itemID,
        [FromBody] RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase )

    {
       var id =  useCase.Execute(itemID, request);
      
        return Created(string.Empty, id);
    }
}
