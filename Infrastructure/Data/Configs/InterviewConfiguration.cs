using Domain.AggregatesModel.InterviewAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
  public void Configure(EntityTypeBuilder<Interview> builder)
  {
    builder.HasKey(x => x.Id);
    builder.
      HasOne(static interview => interview.Survey); 
    builder.
      HasMany(static interview => interview.Results).
      WithOne(static result => result.Interview);
  }
}