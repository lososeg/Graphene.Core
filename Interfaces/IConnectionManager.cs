﻿using System.Threading;
using System.Threading.Tasks;
using Graphene.Core.JsonRpc;
using Newtonsoft.Json;

namespace Graphene.Core.Interfaces
{
    public interface IConnectionManager
    {
        bool IsConnected { get; }

        Task<bool> ConnectToAsync(string endpoin, CancellationToken token);

        void Disconnect();

        Task<JsonRpcResponse<T>> ExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, CancellationToken token);

        Task<JsonRpcResponse<T>> RepeatExecuteAsync<T>(IJsonRpcRequest jsonRpc, JsonSerializerSettings jsonSerializerSettings, CancellationToken token);
    }
}