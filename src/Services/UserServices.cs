using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.DTOs.User.Requests;
using TimeasyAPI.src.DTOs.User.Responses;
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
        private ITokenService _tokenService;
        private Serilog.ILogger _logger;
        public UserServices(IGenericRepository<User> userRepository, ITokenService tokenService, IGenericRepository<Institute> instituteRepository,
                            IUnitOfWork unitOfWork, Serilog.ILogger logger)
        {
            _userRepository = userRepository;
            _instituteRepository = instituteRepository;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CreateUserResponse> CreateRootUserAsync(CreateUserRequest request)
        {
            try
            {
                if (await UserWithEmailExists(request.Email))
                {
                    throw new AppException("Email informado já está sendo utilizado.");
                }

                if (!request.Password.Equals(request.ConfirmPassword))
                {
                    throw new AppException("As senhas não conferem.");
                }
    
                var createUserRequest = request.MapToEntity();
                createUserRequest.AcessLevel = AcessLevel.Root;

                _unitOfWork.CreateTransaction();
                await _userRepository.CreateAsync(createUserRequest);
                await _instituteRepository.CreateAsync(createUserRequest.Institute);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();

                return createUserRequest.EntityToMap();
                              
            }
            catch (AppException)
            {
                _logger.Error($"Erro ao criar usuário root. Email em uso ${request.Email}.");
                throw;
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.Error($"Erro ao criar usuário root. {e.Message}");
                throw new AppException(e.Message);
            }
        }

        public async Task<AuthResponse> AuthAsync(AuthRequest request)
        {
            var user = await _userRepository.FindAsync(user => user.Email.Equals(request.Email));

            if (user is null)
            {
                throw new AppException("Usuário não encontrado.");
            }

            if (!user.Password.Equals(request.Password))
            {
                throw new AppException("Senha inválida.");
            }

            AuthResponse response = user.EntitityToMap();
            response.Token = _tokenService.GenerateToken(user);

            return response;
        }

        private async Task<bool> UserWithEmailExists(string email)
        {
            var existingUser = await _userRepository.FindAsync(user => user.Email.Equals(email));
            return existingUser != null;
        }
    }
}
