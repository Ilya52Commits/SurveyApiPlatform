using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Extensions;

public static class ServiceCollectionsExtensions
{
  public static void AddInfrastructureServices(this IServiceCollection services,
    IConfigurationManager configurationManager, ILogger logger)
  {
    logger.LogInformation("Adding infrastructure services...");

    var dbConnectionString = configurationManager.GetConnectionString("DefaultConnection");

    logger.LogInformation("Adding context...");
    services.AddDbContext<DbContext, Context>(options =>
      options.UseLazyLoadingProxies()
        .UseNpgsql(dbConnectionString).LogTo(Console.WriteLine, LogLevel.Information));

    logger.LogInformation("Adding repository...");
    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
  }
}