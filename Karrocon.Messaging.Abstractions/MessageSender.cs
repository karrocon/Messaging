using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public abstract class MessageSender : IMessageSender
    {
        public string Id { get; private set; }

        public MessageSender(string id)
        {
            Id = id;
        }

        public abstract Task Send<TRequest>(TRequest message, CancellationToken cancellationToken = default) where TRequest : IMessage;
        public abstract Task<TResponse> Send<TRequest, TResponse>(TRequest message, CancellationToken cancellationToken = default) where TRequest : IMessage<TResponse>;
    }
}
