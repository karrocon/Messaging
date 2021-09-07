using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public abstract class MessagePublisher : IMessagePublisher
    {
        public string Id { get; private set; }

        public MessagePublisher(string id)
        {
            Id = id;
        }

        public abstract Task Publish<TRequest>(TRequest message, IMessageOptionDictionary messageOptions = default, CancellationToken cancellationToken = default) where TRequest : IMessage;
    }
}
