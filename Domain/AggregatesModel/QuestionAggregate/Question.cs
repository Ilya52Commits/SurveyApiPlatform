using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.AnswerAggregate;
using Domain.AggregatesModel.ResultAggregate;
using Domain.AggregatesModel.SurveyAggregate;

namespace Domain.AggregatesModel.QuestionAggregate;

public class Question : EntityBase, IAggregateRoot
{
  protected Question() { }

  public Question(string questionText, int surveyId, int? nextQuestionId)
  {
    QuestionText = questionText;
    SurveyId = surveyId;
    NextQuestionId = nextQuestionId;
  }
  [System.ComponentModel.DataAnnotations.Key]
  [Column("id")]
  public int Id { get; init; }

  public string QuestionText { get; init; }
  
  public int? NextQuestionId { get; set; } // Ссылка на следующий вопрос
  
  public int SurveyId { get; init; }
  [JsonIgnore] 
  public virtual Survey Survey { get; init; }
  
  public int? ResultId { get; init; }
  public virtual Result? Result { get; init; }
  
  public virtual ICollection<Answer> Answers { get; init; } = new List<Answer>();
}