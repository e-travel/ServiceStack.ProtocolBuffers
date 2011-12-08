using System;
using System.IO;
using ProtoBuf;
using ProtoBuf.Meta;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace ServiceStack.ProtocolBuffers
{
    public class ProtocolBuffersFormat
    {
        public static void Register(IAppHost appHost)
        {
            appHost
                .ContentTypeFilters
                .Register(ContentType.ProtoBuf, SerializeToStream, DeserializeFromStream);
        }

        public static void SerializeToStream(IRequestContext requestContext, object response, Stream stream)
        {
            Serializer.Serialize(stream, response);
        }

        public static object DeserializeFromStream(Type type, Stream stream)
        {
            return (RuntimeTypeModel.Default).Deserialize(stream, null, type);
        }
    }
}
