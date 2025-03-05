using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Application.CQRS.Questions.Commands;

public sealed record AnswerCommand(int SurveyId, int InterviewId, int QuestionId, int AnswerId):ICommand<Result<int>>;