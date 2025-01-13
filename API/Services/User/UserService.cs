using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.User
{
    public class UserService : IUserService
    {
        /*  private readonly DataContext _context;

          public UserService(DataContext context)
          {
              _context = context;
          }

          public async Task<AppUser> GetUserByIdAsync(int id)
          {
              return await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
          }

          public async Task<List<AppUser>> GetUsersAsync()
          {
              return await _context.AppUsers.ToListAsync();
          }*/
        public Task<AppUser> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
