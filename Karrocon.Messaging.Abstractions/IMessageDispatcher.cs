using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public interface IMessageDispatcher
    {
        Task<object> Dispatch(PackedMessage wrappedMessage, CancellationToken cancellationToken);
    }
}
