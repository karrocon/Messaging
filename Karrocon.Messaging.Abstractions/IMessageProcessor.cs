using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public interface IMessageProcessor
    {
        string Id { get; }
        IMessageProcessingOptionDictionary ProcessingOptions { get; }
        
        Task StartProcessingMessagesAsync(CancellationToken cancellationToken = default);
        Task StartProcessingMessagesAsync(IMessageProcessingOptionDictionary options = default, CancellationToken cancellationToken = default);
        Task StopProcessingMessagesAsync(CancellationToken cancellationToken = default);
    }
}
