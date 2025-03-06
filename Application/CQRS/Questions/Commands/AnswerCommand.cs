using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Application.CQRS.Questions.Commands;

public sealed record AnswerCommand(int InterviewId, int QuestionId, int AnswerId):ICommand<Result<int>>;