using Domain.AggregatesModel.SurveyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
  public void Configure(EntityTypeBuilder<Survey> builder)
  {
    builder.HasKey(x => x.Id);
    builder.
      HasMany(static survey => survey.Questions).
      WithOne(static question => question.Survey); 
  }
}