using Domain.AggregatesModel.AnswerAggregate;

namespace API.ResponseModels.Questions;

public sealed record ContentResponse(string QuestionText, List<Answer> Answers);
