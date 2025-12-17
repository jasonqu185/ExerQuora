using MediatR;

namespace Zhaoxi.Zhihu.SharedKernel.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}