using AuctionProject.API.Repositories;
using AuctionProject.API.Entities;
using AuctionProject.API.Contracts;
namespace AuctionProject.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor; 
    private readonly IUserRepository _repository;



    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) 
    {
         _httpContextAccessor = httpContext;
        _repository = repository;

    }
    public User User()
    {
     

        var token = TokenOnRequest();
        var email = FromBase64String(token);


        return _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missing");
        }

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
