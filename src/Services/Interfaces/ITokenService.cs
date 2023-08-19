using System.Security.Claims;
using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);

        string GetInstituteIdByCurrentUser(ClaimsPrincipal user);

        string GetUserIdByCurrentUser(ClaimsPrincipal user);
    }
}
