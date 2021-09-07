using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public interface IMessageHandler
    {
        Task<object> Handle(object request, CancellationToken cancellationToken);
    }

    public interface IMessageHandler<TRequest> : IMessageHandler where TRequest : IMessage
    {
        Task Handle(TRequest request, CancellationToken cancellationToken);
    }

    public interface IMessageHandler<TRequest, TResponse> : IMessageHandler where TRequest : IMessage<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
