using TimeasyAPI.src.Data;
using TimeasyAPI.src.DTOs;
using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class UserServices : IUserService
    {
        private IUnitOfWork<TimeasyDbContext> _unitOfWork;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Institute> _instituteRepository;
        public UserServices(IGenericRepository<User> userRepository, IGenericRepository<Institute> instituteRepository,
                            IUnitOfWork<TimeasyDbContext> unitOfWork)
        {
            _userRepository = userRepository;
            _instituteRepository = instituteRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<UserDTO> Auth(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<CreateUserResponse> CreateRootUser(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
