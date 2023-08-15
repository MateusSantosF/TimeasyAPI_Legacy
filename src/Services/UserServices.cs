using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Models.ValueObjects.Enums;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class UserServices : IUserServices
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Institute> _instituteRepository;
        private Serilog.ILogger _logger;
        public UserServices(IGenericRepository<User> userRepository, IGenericRepository<Institute> instituteRepository,
                            IUnitOfWork unitOfWork, Serilog.ILogger logger)
        {
            _userRepository = userRepository;
            _instituteRepository = instituteRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public Task<UserDTO> Auth(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateRootUserAsync(CreateUserRequest request)
        {
            try
            {
                if (await UserWithEmailExists(request.Email))
                {
                    throw new AppException("Email já está sendo utilizado.");
                }
    
                var createUserRequest = request.MapToEntity();
                createUserRequest.AcessLevel = AcessLevel.Administrator;

                _unitOfWork.CreateTransaction();
                await _userRepository.CreateAsync(createUserRequest);
                await _instituteRepository.CreateAsync(createUserRequest.Institute);
                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();

                return createUserRequest.EntityToMap();
                              
            }
            catch (AppException)
            {
                _logger.Error($"Erro ao criar usuário root. Email em uso.");
                throw;
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.Error($"Erro ao criar usuário root. {e.Message}");
                throw new AppException(e.Message);
            }
        }

        private async Task<bool>  UserWithEmailExists(string email)
        {
            var existingUser = await _userRepository.FindAsync(user => user.Email.Equals(email));
            return existingUser != null;
        }
    }
}
