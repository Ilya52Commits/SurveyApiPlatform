using Application.CQRS.Questions.Queries;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.AnswerAggregate;
using Domain.AggregatesModel.QuestionAggregate;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Questions.Handlers;

internal class ContentQueryHandler(
    IReadRepository<Question> readRepository,
    ILogger<ContentQueryHandler> logger):IQueryHandler<ContentQuery, Result<(string, ICollection<Answer>)>>
{
    public async Task<Result<(string, ICollection<Answer>)>> Handle(ContentQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting handling {Query}", nameof(ContentQueryHandler));

        try
        {
            var question = await readRepository.GetByIdAsync(request.QuestionId, cancellationToken);

            if (question is null)
            {
                logger.LogWarning("Question with id: {QuestionId} not found", request.QuestionId);
                return Result.NotFound($"Question by id {request.QuestionId} not found");
            }

            var questionText = question.QuestionText;
            var answers = question.Answers;

            logger.LogInformation("{Query} handled successful", nameof(ContentQueryHandler));

            return Result.Success((questionText, answers));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error handling {Query}", nameof(ContentQueryHandler));
            return Result.Error("An error occurred while processing your request.");
        }
    }
}