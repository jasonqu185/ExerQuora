using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Domain;

namespace Zhaoxi.Zhihu.Core.AppUserAggregate.Events;

internal class FollowQuestionAddedEvent(FollowQuestion followQuestion) : BaseEvent
{
    public FollowQuestion FollowQuestion { get; } = followQuestion;
}