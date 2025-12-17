using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Specification;

namespace Zhaoxi.Zhihu.Core.QuestionAggregate.Specifications;

public class QuestionWithAnswerByCreatedBy : Specification<Question>
{
    public QuestionWithAnswerByCreatedBy(int userId, int questionId)
    {
        FilterCondition = q => q.Id == questionId && q.CreatedBy == userId;
        AddInclude(q=>q.Answers.Take(1));
    }
}
