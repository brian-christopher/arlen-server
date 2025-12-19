using System.Text.Json;

namespace Arlen.Network;

public class Message
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };
    
    private readonly JsonDocument _document;
    
    public string RawData { get; }

    public Opcode Opcode => (Opcode)_document
        .RootElement
        .GetProperty("opcode").GetInt32();
    
    public Message(string rawData)
    {
        RawData = rawData;
        _document = JsonDocument.Parse(RawData);    
    }

    public T As<T>() where T : class
    {
        return _document.RootElement.Deserialize<T>(Options)!;
    }
}