using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.DTOs.User.Requests;
using TimeasyAPI.src.DTOs.User.Responses;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IUserServices
    {

        public Task<AuthResponse> AuthAsync(AuthRequest request);

        public Task<CreateUserResponse> CreateRootUserAsync(CreateUserRequest request);
    }
}
