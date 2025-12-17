using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;

namespace Zhaoxi.Zhihu.UseCases.Common.Interfaces;

public interface IDataQueryService
{
    public IQueryable<AppUser> AppUsers { get; }

    public IQueryable<FollowQuestion> FollowQuestions { get; }

    public IQueryable<FollowUser> FollowUsers { get; }

    public IQueryable<Question> Questions { get; }

    public IQueryable<Answer> Answers { get; }

    public IQueryable<AnswerLike> AnswerLikes { get; }

    Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> queryable) where T : class;

    Task<IList<T>> ToListAsync<T>(IQueryable<T> queryable) where T : class;
}