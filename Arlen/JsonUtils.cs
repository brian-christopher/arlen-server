using System.Text.Json;

namespace Arlen;

public static class JsonUtils
{
    public static readonly JsonSerializerOptions SnakeCaseOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static T DeserializeSnakeCase<T>(string json) where T : class
    {
        return JsonSerializer.Deserialize<T>(json, SnakeCaseOptions)!;
    }

    public static string SerializeSnakeCase<T>(T obj) where T : class
    {
        return JsonSerializer.Serialize(obj, SnakeCaseOptions);
    }
}
