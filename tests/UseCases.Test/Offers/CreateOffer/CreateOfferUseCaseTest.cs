using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using AuctionProject.API.Repositories.DataAccess;
using AuctionProject.API.Services;
using AuctionProject.API.UseCases.Auctions.GetCurrent;
using AuctionProject.API.UseCases.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Test.Offers.CreateOffer;
 public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int ItemId)
    {

        var request = new Faker<RequestCreateOfferJson>()
     
        .RuleFor(request => request.Price, f => f.Random.Decimal(1, 400)).Generate();
        

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());


        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        var act = () => useCase.Execute(ItemId, request);
     
        act.Should().NotThrow();
    }
}
