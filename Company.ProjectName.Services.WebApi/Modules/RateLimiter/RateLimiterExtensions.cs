using Microsoft.AspNetCore.RateLimiting;

namespace Company.ProjectName.Services.WebApi.Modules.RateLimiter
{
    public static class RateLimiterExtensions
    {
        public static IServiceCollection AddRatelimiting(this IServiceCollection services, IConfiguration configuration)
        {
            var fixedWindowPolicy = "fixedWindow";
            services.AddRateLimiter(configureOptions => {
                configureOptions.AddFixedWindowLimiter(policyName: fixedWindowPolicy, fixedWindow =>
                {
                    fixedWindow.PermitLimit = int.Parse(configuration["RateLimiting:PermitLimit"]);
                    fixedWindow.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimiting:Window"]));
                    fixedWindow.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    fixedWindow.QueueLimit = int.Parse(configuration["RateLimiting:QueueLimit"]);
                });
                configureOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });

            return services;
        }
    }
}
