using System;
using System.IO;

namespace Graphene.Core.Interfaces
{
    public interface IMessageSerializer
    {
        void AddToMessageStream(Stream stream, Type type, object val);

        byte[] Serialize<T>(object obj);
    }
}