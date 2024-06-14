using Components_Namespace;
using Core;

namespace Commands;

public record Attack_Command(Components Entity, Components Target)
    : Command<Attack_Command>()
{
}
