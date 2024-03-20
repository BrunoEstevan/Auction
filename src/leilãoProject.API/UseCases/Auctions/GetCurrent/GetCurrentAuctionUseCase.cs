using AuctionProject.API.Entities;
using AuctionProject.API.Repositories;
using Microsoft.EntityFrameworkCore;    
using AuctionProject.API.Contracts;
using System.Security.Cryptography.X509Certificates;


namespace AuctionProject.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{

    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;
    public Auction? Execute()
    {
       return  _repository.GetCurrent();
    
    }
}
