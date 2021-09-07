using System.Collections.Generic;

namespace Karrocon.Messaging
{
    public interface IMessageProcessingOptionDictionary : IDictionary<string, object>
    {
        new object this[string key] { get; set; }
    }
}
