using API.Entities;
using API.Services.Token;
using API.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
          private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
    public UserController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService=tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string email, string password,string role)
    {
        var result = await _userService.RegisterWithRoleAsync(username, email, password,role);
        if (result.Succeeded)
        {
            return Ok("User registered successfully");
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
       var user = await _userService.LoginAsync(username,password);
    if (user == null )
    {
        return Unauthorized("Invalid credentials");
    }

   
    var token =await _tokenService.GenerateJwtTokenAsync(user);

    return Ok(new { Token = token });
    }
    }
}
