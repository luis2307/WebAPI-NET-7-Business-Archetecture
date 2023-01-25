using Company.ProjectName.Services.WebApi.Modules.Authentication;
using Company.ProjectName.Services.WebApi.Modules.Feature;
using Company.ProjectName.Services.WebApi.Modules.HealthCheck;
using Company.ProjectName.Services.WebApi.Modules.Injection;
using Company.ProjectName.Services.WebApi.Modules.Mapper;
using Company.ProjectName.Services.WebApi.Modules.Redis;
using Company.ProjectName.Services.WebApi.Modules.Swagger;
using Company.ProjectName.Services.WebApi.Modules.Validator;
using Company.ProjectName.Services.WebApi.Modules.Versioning;
using Company.ProjectName.Services.WebApi.Modules.Watch;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddValidator();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDog(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // build a swagger endpoint for each discovered API version
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}
app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors("policyApiProjectName");
app.UseRouting(); 
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(_ => { });
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseWatchDog(conf =>
{
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});


app.Run();


public partial class Program { };

// TODO: eliminar response headers