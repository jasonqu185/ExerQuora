using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zhaoxi.Zhihu.Core.Data;
using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;

namespace Zhaoxi.Zhihu.Infrastructure.Data.Configuration;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DefaultQuestionTitleLength)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnType("text");
    }
}