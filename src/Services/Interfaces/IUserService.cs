using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.DTOs;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IUserService
    {

        public Task<UserDTO> Auth(string email, string password);

        public Task<CreateUserResponse> CreateRootUser(CreateUserRequest request);
    }
}
