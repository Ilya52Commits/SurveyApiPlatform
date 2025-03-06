using FastEndpoints;

namespace API.Extensions;

/// <summary>
///     Service collection extensions
/// </summary>
public static class ServiceExtensions
{
  /// <summary>
  ///    Add api services to service collections
  /// </summary>
  /// <param name="services"></param>
  /// <param name="logger"></param>
  public static void AddApiServices(this IServiceCollection services, ILogger logger)
  {
    logger.LogInformation("Adding api services...");
    
    logger.LogInformation("Adding swagger...");
    services.AddSwaggerGen(static c => { c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" }); });
    
    logger.LogInformation("Adding fast endpoints...");
    services.AddFastEndpoints();
  }
}