using TimeasyAPI.src.Repositories;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Helpers
{
    public static class ServiceCollection
    {
        public static void RegisterDependencies(this IServiceCollection serviceCollection) {
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IUnitOfWork,UnitOfWork.UnitOfWork>();
            serviceCollection.AddScoped<IUserServices, UserServices>();
        }
    }
}
