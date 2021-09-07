using System;

namespace Karrocon.Messaging
{
    public interface IMessageHandlerResolver
    {
        IMessageHandler GetHandler(Type messageType, Type responseType = null);
    }
}
