using MediatR;

namespace Zhaoxi.Zhihu.SharedKernel.Messaging;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}