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
    switch (result.Status)
    {
      case ResultStatus.Ok: 
        return ep.HttpContext.Response.SendAsync(mapper(result));
      
      case ResultStatus.NoContent:
        return ep.HttpContext.Response.SendNoContentAsync();
      
      case ResultStatus.NotFound:
        return ep.HttpContext.Response.SendNotFoundAsync();
      
      case ResultStatus.Error:
        return ep.HttpContext.Response.SendErrorAsync(result.Errors.FirstOrDefault() ?? "An error occurred.");
      
      default:
        return ep.HttpContext.Response.SendErrorAsync("An unexpected result status was encountered.");
    }
    
  }
  private static Task SendErrorAsync(this HttpResponse response, string errorMessage)
  {
    response.StatusCode = StatusCodes.Status500InternalServerError;
    return response.WriteAsync(errorMessage);
  }
}