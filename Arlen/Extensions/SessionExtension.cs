using Arlen.Network;
using SuperSocket.WebSocket.Server;
using System.Text.Json;

namespace Arlen.Extensions;

public static class SessionExtension
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static async ValueTask SendAsync<T>(this GameSession session, T message) where T : INetworkMessage
    {
        try
        {
            ArgumentNullException.ThrowIfNull(message);
            ArgumentNullException.ThrowIfNull(session);

            var json = JsonSerializer.Serialize(message, Options);

            await session.SendAsync(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message to session. {ex.Message}");
        }
    }
}
