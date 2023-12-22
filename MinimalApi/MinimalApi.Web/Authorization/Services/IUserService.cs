using MinimalApi.Web.Authorization.Models;

namespace MinimalApi.Web.Authorization.Services;

public interface IUserService
{
    Task<User> Authenticate(string username, string password);
}