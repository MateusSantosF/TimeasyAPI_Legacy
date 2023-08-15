using TimeasyAPI.src.DTOs.User;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IUserServices
    {

        public Task<UserDTO> Auth(string email, string password);

        public Task<CreateUserResponse> CreateRootUserAsync(CreateUserRequest request);
    }
}
