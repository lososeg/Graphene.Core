namespace Graphene.Core.Interfaces
{
    public interface IJsonRpcRequest
    {
        int Id { get; }

        string Message { get; }
    }
}