using System.Text.Json;

namespace Arlen.Network;

public class ParsedCommand(string rawJson)
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    private readonly JsonDocument _document
        = JsonDocument.Parse(rawJson);

    public Opcode Opcode => (Opcode)_document
        .RootElement
        .GetProperty("opcode").GetInt32();

    public T As<T>() where T : class
    {
        return _document.RootElement.Deserialize<T>(Options)!;
    }
}
