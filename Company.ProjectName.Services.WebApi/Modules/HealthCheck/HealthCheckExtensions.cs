namespace Company.ProjectName.Services.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "Database" })
                .AddRedis(configuration.GetConnectionString("RedisConnection"), tags: new[] { "Cache" })
                .AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] { "custom" });

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
