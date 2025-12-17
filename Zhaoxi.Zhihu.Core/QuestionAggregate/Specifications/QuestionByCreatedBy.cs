using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Specification;

namespace Zhaoxi.Zhihu.Core.QuestionAggregate.Specifications;

public class QuestionByCreatedBy : Specification<Question>
{
    public QuestionByCreatedBy(int userId, int questionId)
    {
        FilterCondition = q => q.Id == questionId && q.CreatedBy == userId;
    }
}
