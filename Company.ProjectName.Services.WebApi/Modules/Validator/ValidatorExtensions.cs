using Company.ProjectName.Application.Validator.Users;

namespace Company.ProjectName.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UsersDtoValidator>();
            services.AddTransient<UserRegisterRequestDtoValidator>();

            return services;
        }
    }
}
