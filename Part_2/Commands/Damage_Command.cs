using Core;

namespace Commands;

public record Damage_Command(Components Entity, int Amount) : Command
{
}
