using MinimalApi.Web.Authorization.Models;

namespace MinimalApi.Web.Authorization.Services;

internal class UserService : IUserService
{
    private readonly List<User> _users = new()
    {
        new User
        {
            Username = "vs", Password = "rekrutacja"
        }
    };

    public async Task<User> Authenticate(string username, string password)
    {
        var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

        return user;
    }
}