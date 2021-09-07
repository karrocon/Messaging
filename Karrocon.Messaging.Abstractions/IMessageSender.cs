using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public interface IMessageSender
    {
        string Id { get; }

        Task Send<TRequest>(TRequest message, CancellationToken cancellationToken = default) where TRequest : IMessage;
        Task<TResponse> Send<TRequest, TResponse>(TRequest message, CancellationToken cancellationToken = default) where TRequest : IMessage<TResponse>;
    }
}
