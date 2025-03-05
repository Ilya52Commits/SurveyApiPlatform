using Application.CQRS.Questions.Queries;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.AnswerAggregate;
using Domain.AggregatesModel.QuestionAggregate;

namespace Application.CQRS.Questions.Handlers;

public class ContentQueryHandler(
  IReadRepository<Question> readRepository) : IQueryHandler<ContentQuery, Result<(string, ICollection<Answer>)>>
{
  public async Task<Result<(string, ICollection<Answer>)>> Handle(ContentQuery request, CancellationToken cancellationToken)
  {
    var question = await readRepository.GetByIdAsync(request.QuestionId, cancellationToken);

    var QuestionText = question.QuestionText;
    var Answers = question.Answers;
    
    return Result.Success((QuestionText, Answers));
  }
}