namespace API.RequestModels.Questions;

public class AnswerRequest
{
    public required int QuestionId { get; set; }
    public required int InterviewId { get; set; }
    public required int AnswerId { get; set; }
}