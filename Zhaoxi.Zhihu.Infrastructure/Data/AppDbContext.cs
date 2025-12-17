using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;

namespace Zhaoxi.Zhihu.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityUserContext<IdentityUser, int>(options)
{
    public DbSet<Question> Questions => Set<Question>();

    public DbSet<Answer> Answers => Set<Answer>();

    public DbSet<AnswerLike> AnswerLikes => Set<AnswerLike>();
    public DbSet<AppUser> AppUsers => Set<AppUser>();

    public DbSet<FollowUser> FollowUsers => Set<FollowUser>();

    public DbSet<FollowQuestion> FollowQuestions => Set<FollowQuestion>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}