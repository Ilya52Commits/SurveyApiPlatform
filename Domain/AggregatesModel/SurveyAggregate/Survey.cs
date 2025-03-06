using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.QuestionAggregate;

namespace Domain.AggregatesModel.SurveyAggregate;

public class Survey:EntityBase, IAggregateRoot
{
    protected Survey() { }

    public Survey(string surveyText)
    {
        Guard.Against.NullOrWhiteSpace(surveyText, nameof(surveyText), "Survey text cannot be null or empty.");
        SurveyText = surveyText;
    }

    [Key] [Column("id")] public new int Id { get; init; }
    [JsonIgnore] public string SurveyText { get; init; }
    public virtual ICollection<Question> Questions { get; init; } = new List<Question>();
}