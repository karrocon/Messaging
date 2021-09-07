namespace Karrocon.Messaging
{
    public interface IMessage { }

    public interface IMessage<TResponse> : IMessage { }
}
