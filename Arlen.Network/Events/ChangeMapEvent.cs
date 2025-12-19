namespace Arlen.Network.Events;

public record ChangeMapEvent(int MapId) : IPackage
{
    public Opcode Opcode => Opcode.ChangeMap; 
}