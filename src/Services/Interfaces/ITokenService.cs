using System.Security.Claims;
using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);

        Guid GetInstituteIdByCurrentUser(ClaimsPrincipal user);

        Guid GetUserIdByCurrentUser(ClaimsPrincipal user);
    }
}
