using Domain.AggregatesModel.QuestionAggregate;
using Domain.AggregatesModel.ResultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

internal class ResultConfiguration:IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(static x => x.Id);

        builder
            .HasOne(static result => result.Interview)
            .WithMany(static interview => interview.Results).OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(static result => result.Question)
            .WithOne(static question => question.Result).HasForeignKey<Question>(static question => question.ResultId);

        builder
            .HasOne(static result => result.Answer);
    }
}