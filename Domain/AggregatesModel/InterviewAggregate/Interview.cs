using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.ResultAggregate;
using Domain.AggregatesModel.SurveyAggregate;

namespace Domain.AggregatesModel.InterviewAggregate;

public class Interview : EntityBase, IAggregateRoot
{
  protected Interview() { }

  public Interview(string userName, int surveyId)
  {
    UserName = userName;
    SurveyId = surveyId;
  }

  [System.ComponentModel.DataAnnotations.Key]
  [Column("id")]
  public int Id { get; init; }
  
  public string UserName { get; init; } 
  
  public int SurveyId { get; init; }
  public virtual Survey Survey { get; init; }

  public virtual ICollection<Result> Results { get; init; } = new List<Result>();
}