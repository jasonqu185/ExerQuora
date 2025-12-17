using Zhaoxi.Zhihu.Core.Common;

namespace Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;

public class FollowQuestion : BaseEntity
{
    public int UserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public int QuestionId { get; set; }

    public DateTimeOffset FollowDate { get; set; }
}