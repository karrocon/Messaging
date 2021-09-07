using System.Threading;
using System.Threading.Tasks;

namespace Karrocon.Messaging
{
    public abstract class MessageHandler : IMessageHandler
    {
        public abstract Task<object> Handle(object request, CancellationToken cancellationToken);
    }

    public abstract class MessageHandler<TRequest> : MessageHandler, IMessageHandler<TRequest> where TRequest : IMessage
    {
        public abstract Task Handle(TRequest request, CancellationToken cancellationToken);

        public override async Task<object> Handle(object request, CancellationToken cancellationToken)
        {
            await Handle((TRequest)request, cancellationToken).ConfigureAwait(false);

            return true;
        }
    }

    public abstract class MessageHandler<TRequest, TResponse> : MessageHandler, IMessageHandler<TRequest, TResponse> where TRequest : IMessage<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public override async Task<object> Handle(object request, CancellationToken cancellationToken)
        {
            return await Handle((TRequest)request, cancellationToken);
        }
    }
}
