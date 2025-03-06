using Ardalis.Result;
using FastEndpoints;
using IResult = Ardalis.Result.IResult;

namespace API.Extensions;

internal static class ResultExtensions
{
    internal static Task SendResponse<TResult, TResponse>(
        this IEndpoint ep,
        TResult result,
        Func<TResult, TResponse> mapper) where TResult : IResult
    {
        return result.Status switch
        {
            ResultStatus.Ok => ep.HttpContext.Response.SendAsync(mapper(result)),
            ResultStatus.NoContent => ep.HttpContext.Response.SendNoContentAsync(),
            ResultStatus.NotFound => ep.HttpContext.Response.SendNotFoundAsync(),
            ResultStatus.Error => ep.HttpContext.Response.SendErrorAsync(result.Errors.FirstOrDefault() ?? "An error occurred."),
            _ => ep.HttpContext.Response.SendErrorAsync("An unexpected result status was encountered.")
        };
    }

    private static Task SendErrorAsync(this HttpResponse response, string errorMessage)
    {
        response.StatusCode = StatusCodes.Status500InternalServerError;
        return response.WriteAsync(errorMessage);
    }
}