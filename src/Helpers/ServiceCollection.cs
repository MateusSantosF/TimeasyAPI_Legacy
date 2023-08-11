using TimeasyAPI.src.Services;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.src.Helpers
{
    public static class ServiceCollection
    {
        public static void RegisterDependencies(this IServiceCollection serviceCollection) {

            serviceCollection.AddScoped<ITokenService, TokenService>();
        }
    }
}
