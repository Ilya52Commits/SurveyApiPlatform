using Application.CQRS.Questions.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Extensions;

public static class ServiceExtensions
{
  public static void AddApplicationServices(this IServiceCollection services, ILogger logger)
  {
    logger.LogInformation("Adding application services...");
    
    logger.LogInformation("Adding mediator...");
    services.AddMediatR(static cfg => cfg.RegisterServicesFromAssembly(typeof(AnswerCommand).Assembly)); 
  }
}