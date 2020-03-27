using System.IO;

namespace Graphene.Core.Interfaces
{
    public interface ICustomSerializer
    {
        void Serializer(Stream stream, IMessageSerializer serializeHelper);
    }
}