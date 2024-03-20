using AuctionProject.API.Entities;
using Microsoft.EntityFrameworkCore;
using AuctionProject.API.Contracts;
namespace AuctionProject.API.Repositories.DataAcess;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionProjectDbContext _dbContext;

    public AuctionRepository(AuctionProjectDbContext dbContext) => _dbContext = dbContext;
    
    public Auction? GetCurrent()
    {
          var today = new DateTime(2024, 01, 22);

           return _dbContext

            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today  <= auction.Ends);
    }

 }

