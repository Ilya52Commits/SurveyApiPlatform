using Ardalis.Result;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.AnswerAggregate;

namespace Application.CQRS.Questions.Queries;

public sealed record ContentQuery(int QuestionId):IQuery<Result<(string, ICollection<Answer>)>>;