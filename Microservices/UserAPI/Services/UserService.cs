using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Services;

public class UserService : IUserService
{
    private readonly UserDbContext _context;
    
    public UserService(UserDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetUserListAsync() => await _context.Users.ToListAsync();
    
    public async Task<User?> GetUserByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

    public async Task<User> AddUser(User user)
    {
        var result = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<User> UpdateUser(User user)
    {
        var result = _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var filteredData = await _context.Users.FindAsync(id);
        if (filteredData == null) 
            return false;
        
        _context.Remove(filteredData);
        await _context.SaveChangesAsync();
        return true;
    }
}