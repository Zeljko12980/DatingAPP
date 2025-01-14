using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.User
{
    public class UserService : IUserService
    {
      private readonly UserManager<AppUser> _userManager;
      private readonly RoleManager<IdentityRole> _roleManager;
    public UserService(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager=roleManager;
    }

    // Register a new user
    public async Task<IdentityResult> RegisterWithRoleAsync(string username, string email, string password, string role)
{
    // Create a new user
    var user = new AppUser
    {
        UserName = username,
        Email = email
    };

    // Create the user asynchronously
    var result = await _userManager.CreateAsync(user, password);

    if (result.Succeeded)
    {
        // Check if the role exists
        var roleExists = await _roleManager.RoleExistsAsync(role);
        
        if (!roleExists)
        {
            // Create the role if it doesn't exist
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));

            if (!roleResult.Succeeded)
            {
                // Return an error if role creation fails
                return IdentityResult.Failed(roleResult.Errors.ToArray());
            }
        }

        // Add the user to the role
        await _userManager.AddToRoleAsync(user, role);
    }

    // Return the result of user creation
    return result;
}


    // Login user (validate credentials)
    public async Task<AppUser> LoginAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            return user;
        }
        return null;
    }

    // Retrieve user by ID
    public async Task<AppUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    // Change user's password
    public async Task<IdentityResult> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword)
    {
        return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    // Update user's profile
    public async Task<IdentityResult> UpdateUserAsync(AppUser user)
    {
        return await _userManager.UpdateAsync(user);
    }
    }
}
