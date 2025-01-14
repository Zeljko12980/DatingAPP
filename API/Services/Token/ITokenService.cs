using API.Entities;

namespace API.Services.Token
{
    public interface ITokenService
    {
        Task<string> GenerateJwtTokenAsync(AppUser user);
    }
}