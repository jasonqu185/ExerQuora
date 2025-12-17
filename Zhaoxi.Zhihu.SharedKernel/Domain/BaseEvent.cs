using MediatR;

namespace Zhaoxi.Zhihu.SharedKernel.Domain;

public abstract class BaseEvent : INotification
{
    public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.Now;
}