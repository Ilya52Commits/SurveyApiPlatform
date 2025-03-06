using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Domain.AggregatesModel.ResultAggregate;
using Domain.AggregatesModel.SurveyAggregate;

namespace Domain.AggregatesModel.InterviewAggregate;

public class Interview:EntityBase, IAggregateRoot
{
    protected Interview() { }

    public Interview(string userName, int surveyId)
    {
        Guard.Against.NullOrEmpty(userName, nameof(userName), "User name cannot be null or empty.");
        UserName = userName;

        Guard.Against.NegativeOrZero(surveyId, nameof(surveyId), "SurveyId cannot be less than one");
        SurveyId = surveyId;
    }

    [Key] [Column("id")] public new int Id { get; init; }

    public string UserName { get; init; }

    public int SurveyId { get; init; }
    public virtual Survey Survey { get; init; }

    public virtual ICollection<Result> Results { get; init; } = new List<Result>();
}