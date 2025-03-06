using Application.CQRS.Questions.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Extensions;

/// <summary>
///     Service collection extensions
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    ///     Add application services to service collections
    /// </summary>
    /// <param name="services"> </param>
    /// <param name="logger"> </param>
    public static void AddApplicationServices(this IServiceCollection services, ILogger logger)
    {
        logger.LogInformation("Adding application services...");

        logger.LogInformation("Adding mediator...");
        services.AddMediatR(static cfg => cfg.RegisterServicesFromAssembly(typeof(AnswerCommand).Assembly));
    }
}