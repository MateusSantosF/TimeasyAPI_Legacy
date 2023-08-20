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

            serviceCollection.AddScoped<IRoomRepository, RoomRepository>();
            serviceCollection.AddScoped<IRoomServices, RoomServices>();

            serviceCollection.AddScoped<IRoomTypeServices, RoomTypeServices>();
            serviceCollection.AddScoped<IInstituteServices, InstituteServices>();

            serviceCollection.AddScoped<IIntervalRepository, IntervalRepository>();
            serviceCollection.AddScoped<IInstituteRepository, InstituteRepository>();
            serviceCollection.AddScoped<IIntervalServices, IntervalServices>();

            serviceCollection.AddScoped<ISubjectService, SubjectServices>();
            serviceCollection.AddScoped<ISubjectRepository, SubjectRepository>();

            serviceCollection.AddScoped<ITeacherRepository, TeacherRepository>();
            serviceCollection.AddScoped<ITeacherServices, TeacherServices>();

            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
            serviceCollection.AddScoped<ICourseServices, CourseServices>();

            serviceCollection.AddScoped<ITimetableRepository, TimetableRepository>();
            serviceCollection.AddScoped<ITimetableServices, TimetableServices>();

        }
    }
}
