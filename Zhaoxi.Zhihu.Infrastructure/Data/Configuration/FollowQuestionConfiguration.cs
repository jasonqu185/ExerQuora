using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;

namespace Zhaoxi.Zhihu.Infrastructure.Data.Configuration;

public class FollowQuestionConfiguration : IEntityTypeConfiguration<FollowQuestion>
{
    public void Configure(EntityTypeBuilder<FollowQuestion> builder)
    {
        // 设置组合唯一约束
        builder
            .HasIndex(fq => new { fq.UserId, fq.QuestionId })
            .IsUnique();

        // 设置用户与关注问题列表之间的一对多关系
        builder
            .HasOne(fq => fq.AppUser)
            .WithMany(u => u.FollowQuestions)
            .HasForeignKey(fq => fq.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}