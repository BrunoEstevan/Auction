using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using AuctionProject.API.Enums;
using AuctionProject.API.UseCases.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {

        var entity = new Faker<Auction>()
        .RuleFor(auction => auction.Name, f => f.Lorem.Word())
        .RuleFor(auction => auction.Id, f => f.Random.Number(1, 400))
        .RuleFor(auction => auction.Starts, f => f.Date.Past())
        .RuleFor(auction => auction.Ends, f => f.Date.Future())
        .RuleFor(auction => auction.Items, (f, Auction) => new List<Item>
        {
            new Item
            {
                Id = f.Random.Number(1, 400),
                Name = f.Commerce.ProductName(),
                Brand = f.Commerce.Department(),
                BasePrice = f.Random.Decimal(50, 400),
                Condition =f.PickRandom<Condition>(),
                AuctionId = Auction.Id
            }
        }).Generate();


        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(new AuctionProject.API.Entities.Auction()); 


        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        var auction = useCase.Execute();

     
        auction.Should().NotBeNull();
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);


    }
}
