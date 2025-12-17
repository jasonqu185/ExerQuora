namespace Zhaoxi.Zhihu.Core.Common;

public abstract class BaseAuditEntity : BaseEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? LastModifiedAt { get; set; }
}