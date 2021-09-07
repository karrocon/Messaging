using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public abstract class MessageProcessor : IMessageProcessor
    {
        public string Id { get; protected set; }

        public IMessageProcessingOptionDictionary ProcessingOptions { get; protected set; }

        public MessageProcessor(string id, IMessageProcessingOptionDictionary processingOptions = default)
        {
            Id = id;
            ProcessingOptions = processingOptions;
        }

        public abstract Task StartProcessingMessagesAsync(CancellationToken cancellationToken = default);
        public abstract Task StopProcessingMessagesAsync(CancellationToken cancellationToken = default);

        public Task StartProcessingMessagesAsync(IMessageProcessingOptionDictionary options = default, CancellationToken cancellationToken = default)
        {
            ProcessingOptions = options;

            return StartProcessingMessagesAsync(cancellationToken);
        }
    }
}
