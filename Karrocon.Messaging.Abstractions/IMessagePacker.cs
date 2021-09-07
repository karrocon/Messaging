using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public interface IMessagePacker
    {
        Task<PackedMessage> Pack(IMessage message, CancellationToken cancellationToken);
        Task<IMessage> Unpack(PackedMessage message, CancellationToken cancellationToken);
    }
}
