using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.AnswerAggregate;
using Domain.AggregatesModel.InterviewAggregate;
using Domain.AggregatesModel.QuestionAggregate;

namespace Domain.AggregatesModel.ResultAggregate;

public class Result:EntityBase, IAggregateRoot
{
    protected Result() { }

    public Result(int interviewId, int questionId, int answerId)
    {
        InterviewId = interviewId;
        QuestionId = questionId;
        AnswerId = answerId;
    }

    [Key] [Column("id")] public new int Id { get; init; }
    public int InterviewId { get; init; }
    public virtual Interview Interview { get; init; }

    public int QuestionId { get; init; }
    public virtual Question Question { get; init; }

    public int AnswerId { get; init; }
    public virtual Answer Answer { get; init; }
}