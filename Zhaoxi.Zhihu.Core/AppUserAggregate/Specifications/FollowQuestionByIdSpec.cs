using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Specification;

namespace Zhaoxi.Zhihu.Core.AppUserAggregate.Specifications;

public class FollowQuestionByIdSpec : Specification<AppUser>
{
    public FollowQuestionByIdSpec(int userId, int questionId)
    {
        FilterCondition = user => user.Id.Equals(userId);
        
        AddInclude(user => user.FollowQuestions.Where(fq => fq.QuestionId.Equals(questionId)));
    }
}
