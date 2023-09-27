using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Models.DataTransferObjects;

namespace LoveLiveCZ.DatabaseServices.Interfaces;

public interface IUserDatabaseService
{
    public Task<User> CreateUserAsync(NewUser user);
    
    public Task<User> GetUserAsync(Guid id);
    
    public Task<User> GetUserAsync(string username);

    public Task<bool> UsernameOrEmailExistsAsync(string username, string email);

    public Task<User> UpdateAsync(User user);
}