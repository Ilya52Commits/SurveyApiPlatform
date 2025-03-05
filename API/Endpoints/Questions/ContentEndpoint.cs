using API.Extensions;
using API.RequestModels.Questions;
using API.ResponseModels.Questions;
using FastEndpoints;
using MediatR;
using Application.CQRS.Questions.Queries; 

namespace API.Endpoints.Questions;

public class ContentEndpoint(IMediator mediator):Endpoint<ContentRequest, ContentResponse>
{
  public override void Configure()
  {
    Get("/content");
    AllowAnonymous();
  }

  public override async Task HandleAsync(ContentRequest request, CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new ContentQuery(request.QuestionId), cancellationToken);

    await this.SendResponse(result, static result => 
    {
      var (questionText, answers) = result.Value; // Извлекаем данные из кортежа
      return new ContentResponse(questionText, answers.ToList()); // Преобразуем в ContentResponse
    });
  }
}