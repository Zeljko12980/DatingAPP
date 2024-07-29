using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.User
{
    public interface IUserService
    {
        Task<AppUser> GetUserByIdAsync(int id);
        Task<List<AppUser>> GetUsersAsync();
    }
}
