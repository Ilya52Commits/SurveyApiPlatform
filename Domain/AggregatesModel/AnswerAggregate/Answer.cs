using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.QuestionAggregate;

namespace Domain.AggregatesModel.AnswerAggregate;

public class Answer:EntityBase, IAggregateRoot
{
    protected Answer() { }

    public Answer(int questionId, string answerText)
    {
        Guard.Against.NullOrWhiteSpace(answerText, nameof(answerText), "Answer text cannot be null or empty.");
        AnswerText = answerText;

        Guard.Against.NegativeOrZero(questionId, nameof(questionId), "Question ID cannot be less than one.");
        QuestionId = questionId;
    }

    [Key] [Column("id")] public new int Id { get; init; }
    public string AnswerText { get; init; }
    public int QuestionId { get; init; }
    [JsonIgnore] public virtual Question Question { get; init; }
}