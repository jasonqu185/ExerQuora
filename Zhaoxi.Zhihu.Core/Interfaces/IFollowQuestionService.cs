using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Result;

namespace Zhaoxi.Zhihu.Core.Interfaces;

public interface IFollowQuestionService
{
    Task<IResult> FollowAsync(AppUser appuser, int questionId, CancellationToken cancellationToken);
}
