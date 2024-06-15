using Core;

namespace Commands;

public record Heal_Command(Components Entity, Components Target) : Command
{
}