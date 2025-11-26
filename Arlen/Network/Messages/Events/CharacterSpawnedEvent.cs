namespace Arlen.Network.Messages.Events;

public record CharacterSpawnedEvent(int Id, string Name, int X, int Y)
    : INetworkMessage
{
    public Opcode Opcode => Opcode.SPAWN_CHARACTER_EVENT;
}