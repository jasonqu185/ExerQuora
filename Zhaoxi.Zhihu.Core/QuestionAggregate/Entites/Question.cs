using Zhaoxi.Zhihu.Core.Common;
using Zhaoxi.Zhihu.SharedKernel.Domain;

namespace Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;

public class Question : AuditWithUserEntity, IAggregateRoot
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int ViewCount { get; private set; }

    public int FollowerCount { get; set; }

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public int AddView()
    {
        ViewCount += 1;
        return ViewCount;
    }
}