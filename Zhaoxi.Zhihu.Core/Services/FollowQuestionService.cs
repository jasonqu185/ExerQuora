using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.Core.Interfaces;
using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Repository;
using Zhaoxi.Zhihu.SharedKernel.Result;

namespace Zhaoxi.Zhihu.Core.Services;

public class FollowQuestionService(IReadRepository<Question> questions) : IFollowQuestionService
{
    public async Task<IResult> FollowAsync(AppUser appuser, int questionId, CancellationToken cancellationToken)
    {
        var question = await questions.GetByIdAsync(questionId, cancellationToken);
        if (question == null) return Result.NotFound("关注问题不存在");
        
        var result = appuser.AddFollowQuestion(questionId);
        return Result.From(result);
    }
}
