using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public interface IMessagePublisher
    {
        string Id { get; }

        Task Publish<TRequest>(TRequest message, IMessageOptionDictionary messageOptions = default, CancellationToken cancellationToken = default) where TRequest : IMessage;
    }
}
