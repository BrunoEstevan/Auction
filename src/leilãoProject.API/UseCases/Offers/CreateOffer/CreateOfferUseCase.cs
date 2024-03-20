using AuctionProject.API.Entities;
using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Repositories;
using AuctionProject.API.Services;
using Microsoft.VisualBasic;
using AuctionProject.API.Contracts;

namespace AuctionProject.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _repository;
    public CreateOfferUseCase(ILoggedUser loggedUser , IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }


    public  int Execute(int itemId, RequestCreateOfferJson request)
    {

        

        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = new DateTime(2024, 01, 22),
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };


        _repository.Add(offer);
        return offer.Id; 
    }
}
