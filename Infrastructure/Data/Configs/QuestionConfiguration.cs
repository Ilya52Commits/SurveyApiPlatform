using Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
  public void Configure(EntityTypeBuilder<Question> builder)
  {
    builder.HasKey(x => x.Id);
    builder.
      HasMany(static question => question.Answers).
      WithOne(static answer => answer.Question);
    builder.
      HasOne(static survey => survey.Survey).
      WithMany(static question => question.Questions);
  }
}