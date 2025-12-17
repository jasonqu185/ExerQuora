using Zhaoxi.Zhihu.Core.Common;

namespace Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;

public class AnswerLike : BaseAuditEntity
{
    public int AnswerId { get; set; }
    public Answer Answer { get; set; } = null!;

    public int UserId { get; set; }

    public bool IsLike { get; set; }
}