using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.QuestionAggregate;

namespace Domain.AggregatesModel.SurveyAggregate;

public class Survey : EntityBase, IAggregateRoot
{
  protected Survey() { }

  public Survey(string surveyText) { SurveyText = surveyText; }
  [System.ComponentModel.DataAnnotations.Key]
  [Column("id")]
  public int Id { get; init; }
  [JsonIgnore] 
  public string SurveyText { get; init; }
  public virtual ICollection<Question> Questions { get; init; } = new List<Question>();
}