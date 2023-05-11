using UserAPI.Models;

namespace UserAPI.Services;

public interface IUserService
{
    public Task<IEnumerable<User>> GetUserListAsync();
    public Task<User?> GetUserByIdAsync(int id);
    public Task<User> AddUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<bool> DeleteUser(int id);
}