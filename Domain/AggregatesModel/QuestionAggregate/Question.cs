using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.AnswerAggregate;
using Domain.AggregatesModel.ResultAggregate;
using Domain.AggregatesModel.SurveyAggregate;

namespace Domain.AggregatesModel.QuestionAggregate;

public class Question:EntityBase, IAggregateRoot
{
    protected Question() { }

    public Question(string questionText, int surveyId, int? nextQuestionId)
    {
        Guard.Against.NullOrEmpty(questionText, nameof(questionText), "Question text is required.");
        QuestionText = questionText;

        Guard.Against.NegativeOrZero(surveyId, nameof(surveyId), "SurveyId can not be less than one");
        SurveyId = surveyId;

        NextQuestionId = nextQuestionId;
    }

    [Key] [Column("id")] public new int Id { get; init; }

    public string QuestionText { get; init; }

    public int? NextQuestionId { get; set; }

    public int SurveyId { get; init; }
    [JsonIgnore] public virtual Survey Survey { get; init; }

    public int? ResultId { get; init; }
    public virtual Result? Result { get; init; }

    public virtual ICollection<Answer> Answers { get; init; } = new List<Answer>();
}