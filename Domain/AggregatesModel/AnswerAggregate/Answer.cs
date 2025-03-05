using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.QuestionAggregate;

namespace Domain.AggregatesModel.AnswerAggregate;

public class Answer : EntityBase, IAggregateRoot
{
  protected Answer() { }

  public Answer(int questionId, string answerText)
  {
    QuestionId = questionId;
    AnswerText = answerText;
  } 
  [System.ComponentModel.DataAnnotations.Key]
  [Column("id")]
  public int Id { get; init; }
  public string AnswerText { get; init; }
  public int QuestionId { get; init; }
  [JsonIgnore] 
  public virtual Question Question { get; init; }
}