using System;
using System.Collections.Generic;

namespace Karrocon.Messaging
{
    public class PackedMessage
    {
        public byte[] Body { get; private set; }

        public Dictionary<string, object> Metadata { get; private set; }

        public Type Type { get; private set; }

        public PackedMessage(Type type, byte[] body, Dictionary<string, object> metadata)
        {
            Body = body;
            Metadata = metadata;
            Type = type;
        }
    }
}
