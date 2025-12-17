using MediatR;

namespace Zhaoxi.Zhihu.SharedKernel.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}