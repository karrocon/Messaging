using System;

namespace Karrocon.Messaging
{
    public interface IMessageSerializer
    {
        T Deserialize<T>(byte[] message) where T : IMessage;
        object Deserialize(byte[] message, Type type);
        byte[] Serialize<T>(T message) where T : IMessage;
        byte[] Serialize(object message, Type type);
    }
}
