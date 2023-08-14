using HotChocolate.Fusion.Clients;
using HotChocolate.Transport.Sockets;
using System.Net.WebSockets;

namespace Gateway.Properties;

public sealed class WebSocketConnection : IWebSocketConnection
{
    public ClientWebSocket? WebSocket { get; private set; }

    public async ValueTask<WebSocket> ConnectAsync(
        Uri uri,
        string subProtocol,
        CancellationToken cancellationToken = default)
    {
        if (WebSocket is not null)
        {
            return WebSocket;
        }

        WebSocket = new ClientWebSocket();
        WebSocket.Options.AddSubProtocol(WellKnownProtocols.GraphQL_Transport_WS);
        await WebSocket.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
        return WebSocket;
    }

    public void Dispose() => WebSocket?.Dispose();
}

public sealed class WebSocketConnectionFactory : IWebSocketConnectionFactory
{
    public IWebSocketConnection CreateConnection(string name)
        => new WebSocketConnection();
}
