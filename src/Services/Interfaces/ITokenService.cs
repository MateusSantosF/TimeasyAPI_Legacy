using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
