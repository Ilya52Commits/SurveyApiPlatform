using Domain.AggregatesModel.AnswerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

internal class AnswerConfiguration:IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(static x => x.Id);
        builder.HasOne(static answer => answer.Question).WithMany(static question => question.Answers);
    }
}