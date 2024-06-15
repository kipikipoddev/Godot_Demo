using Components_Namespace;
using Core;

namespace Commands;

public record Heal_Command(Heal_Action_Components Action, Components Target) : Command
{
}