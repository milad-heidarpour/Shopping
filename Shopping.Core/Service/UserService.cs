using Microsoft.EntityFrameworkCore;
using Shopping.Core.Interface;
using Shopping.Database.Context;
using Shopping.Database.Model;

namespace Shopping.Core.Service;

public class UserService : IUser
{
    private readonly DatabaseContext _context;
    public UserService(DatabaseContext context)
    {
        _context = context;
    }
    public async void Dispose()
    {
        if (_context != null) 
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<User> GetUser(string userMobile)
    {
        var user = await _context.Users.Include(u=>u.Role).FirstOrDefaultAsync(u => u.PhoneNumb == userMobile);
        return await Task.FromResult(user);
    }
}
