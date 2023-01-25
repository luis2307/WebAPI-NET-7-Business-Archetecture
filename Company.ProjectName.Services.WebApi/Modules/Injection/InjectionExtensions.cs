using Company.ProjectName.Application.Interface;
using Company.ProjectName.Application.Main;
using Company.ProjectName.Domain.Core;
using Company.ProjectName.Domain.Interface;
using Company.ProjectName.Infrastructure.Data;
using Company.ProjectName.Infrastructure.Interface;
using Company.ProjectName.Infrastructure.Repository;
using Company.ProjectName.Transversal.Common;
using Company.ProjectName.Transversal.Logging;

namespace Company.ProjectName.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
