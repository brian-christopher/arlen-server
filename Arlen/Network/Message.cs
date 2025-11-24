using System.Text.Json;

namespace Arlen.Network;

public class Message
{
    private readonly static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        WriteIndented = false
    };

    public Opcode Opcode { get; set; }
    public string? Payload { get; set; }

    public void SerializePayload<T>(T data) where T : class
    {
        Payload = JsonSerializer.Serialize(data, SerializerOptions);
    }

    public T DeserializePayload<T>() where T : class
    {
        return JsonSerializer.Deserialize<T>(Payload!, SerializerOptions)!;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
