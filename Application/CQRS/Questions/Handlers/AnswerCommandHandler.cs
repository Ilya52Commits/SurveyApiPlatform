using Application.CQRS.Questions.Commands;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.QuestionAggregate;
using Result = Domain.AggregatesModel.ResultAggregate.Result;

namespace Application.CQRS.Questions.Handlers;

public class AnswerCommandHandler(
  IReadRepository<Question> questionReadRepository,
  IRepository<Result> questionRepository) : ICommandHandler<AnswerCommand, Result<int>>
{
  public async Task<Result<int>> Handle(AnswerCommand request, CancellationToken cancellationToken)
  {
    var result = new Result(request.InterviewId, request.QuestionId, request.AnswerId);
    
    await questionRepository.AddAsync(result, cancellationToken);

    var currentQuestion = await questionReadRepository.GetByIdAsync(request.QuestionId, cancellationToken);

    if (currentQuestion?.NextQuestionId == null)
    {
      return Ardalis.Result.Result.NotFound();
    }
    
    return currentQuestion.NextQuestionId.Value;
  }
}