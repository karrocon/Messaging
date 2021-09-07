using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public class MessagePacker : IMessagePacker
    {
        private readonly IMessageSerializer _messageSerializer;

        public MessagePacker(IMessageSerializer messageSerializer)
        {
            _messageSerializer = messageSerializer;
        }

        public Task<PackedMessage> Pack(IMessage message, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PackedMessage(message.GetType(), _messageSerializer.Serialize(message), new Dictionary<string, object>()));
        }

        public Task<IMessage> Unpack(PackedMessage message, CancellationToken cancellationToken)
        {
            return Task.FromResult((IMessage)_messageSerializer.Deserialize(message.Body, message.Type));
        }
    }
}
