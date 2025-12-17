using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.Core.Data;

namespace Zhaoxi.Zhihu.Infrastructure.Data.Configuration;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Nickname)
            .HasMaxLength(DataSchemaConstants.DefaultAppUserNickNameLength);

        builder.Property(p => p.Bio)
            .HasMaxLength(DataSchemaConstants.DefaultAppUserBioLength);
    }
}