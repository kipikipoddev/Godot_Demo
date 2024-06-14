using Components_Namespace;
using Core;

namespace Commands;

public record Heal_Command(Components Entity, Components Target)
    : Command<Heal_Command>()
{
}