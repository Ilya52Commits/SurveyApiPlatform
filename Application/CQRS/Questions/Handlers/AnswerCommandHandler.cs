using Application.CQRS.Questions.Commands;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.QuestionAggregate;
using Microsoft.Extensions.Logging;
using Result = Domain.AggregatesModel.ResultAggregate.Result;

namespace Application.CQRS.Questions.Handlers;

internal class AnswerCommandHandler(
    IReadRepository<Question> questionReadRepository,
    IRepository<Result> questionRepository,
    ILogger<AnswerCommandHandler> logger):ICommandHandler<AnswerCommand, Result<int>>
{
    public async Task<Result<int>> Handle(AnswerCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting handling {Command}", nameof(AnswerCommand));

        try
        {
            var result = new Result(request.InterviewId, request.QuestionId, request.AnswerId);

            await questionRepository.AddAsync(result, cancellationToken);

            logger.LogInformation("Result entity added successfully InterviewId: {InterviewId}, QuestionId: {QuestionId}, AnswerId: {AnswerId}", request.InterviewId, request.QuestionId, request.AnswerId);

            var currentQuestion = await questionReadRepository.GetByIdAsync(request.QuestionId, cancellationToken);

            if (currentQuestion is null)
            {
                logger.LogInformation("Question not found QuestionId {QuestionId}", request.QuestionId);
                return Ardalis.Result.Result.NotFound();
            }

            if (!currentQuestion.NextQuestionId.HasValue)
            {
                logger.LogInformation("Question has not next question QuestionId {QuestionId}", request.QuestionId);
                return Ardalis.Result.Result.NotFound();
            }

            logger.LogInformation("{Command} handled successful", nameof(AnswerCommand));
            return currentQuestion.NextQuestionId.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while handling {Command}", nameof(AnswerCommand));
            return Ardalis.Result.Result.Error("An error occurred while processing your request.");
        }
    }
}