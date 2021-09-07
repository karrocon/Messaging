using System;
using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly IMessageHandlerResolver _handlerResolver;
        private readonly IMessagePacker _packer;

        public MessageDispatcher(IMessagePacker packer, IMessageHandlerResolver handlerResolver)
        {
            _handlerResolver = handlerResolver;
            _packer = packer;
        }

        public async Task<object> Dispatch(PackedMessage packedMessage, CancellationToken cancellationToken)
        {
            if (packedMessage == null)
            {
                // TODO: Include logging
                Console.WriteLine("Unsupported message received. Ignoring...");
                return default;
            }

            var message = await _packer.Unpack(packedMessage, cancellationToken);

            var handler = _handlerResolver.GetHandler(message.GetType());
            if (handler == null)
            {
                // TODO: Include logging
                Console.WriteLine("No handler found. Ignoring...");
                return default;
            }

            return await handler.Handle(message, cancellationToken);
        }
    }
}
