using API.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.User
{
    public interface IUserService
    {Task<IdentityResult> RegisterWithRoleAsync(string username, string email, string password,string role);
    Task<AppUser> LoginAsync(string username, string password);
    Task<AppUser> GetUserByIdAsync(string userId);
    Task<IdentityResult> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword);
    Task<IdentityResult> UpdateUserAsync(AppUser user);
    }
}
