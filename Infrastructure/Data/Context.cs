using Domain.AggregatesModel.AnswerAggregate;
using Domain.AggregatesModel.InterviewAggregate;
using Domain.AggregatesModel.QuestionAggregate;
using Domain.AggregatesModel.ResultAggregate;
using Domain.AggregatesModel.SurveyAggregate;
using Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

internal sealed class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Result> Results { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityByDefaultColumns();

        modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new SurveyConfiguration());
        modelBuilder.ApplyConfiguration(new ResultConfiguration());
        modelBuilder.ApplyConfiguration(new InterviewConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}