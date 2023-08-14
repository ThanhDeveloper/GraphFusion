using Gateway.Properties;
using HotChocolate.Fusion.Clients;
namespace DogGraph.Properties;

public static class Helper
{
    public static IServiceCollection AddWebSocketClient(this IServiceCollection services)
    {
        services.AddSingleton<IWebSocketConnectionFactory, WebSocketConnectionFactory>();
        return services;
    }
}
