using FastEndpoints;

namespace API.Extensions;

public static class ServiceExtensions
{
  public static void AddApiServices(this IServiceCollection services, ILogger logger)
  {
    logger.LogInformation("Adding api services...");
    
    logger.LogInformation("Adding swagger...");
    services.AddSwaggerGen(static c => { c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" }); });
    
    logger.LogInformation("Adding fast endpoints...");
    services.AddFastEndpoints();
  }
}