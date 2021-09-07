using System;

namespace Karrocon.Messaging
{
    public class MessageHandlerResolver : IMessageHandlerResolver
    {
        private readonly IServiceProvider serviceProvider;

        public MessageHandlerResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMessageHandler GetHandler(Type requestType, Type responseType = null)
        {
            var messageHandlerType = responseType == null
                ? typeof(IMessageHandler<>).MakeGenericType(requestType)
                : typeof(IMessageHandler<,>).MakeGenericType(requestType, responseType);

            return serviceProvider.GetService(messageHandlerType) as IMessageHandler;
        }
    }
}
