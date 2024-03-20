using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;

namespace AuctionProject.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly AuctionProjectDbContext _dbContext;

    public UserRepository(AuctionProjectDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));

    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
