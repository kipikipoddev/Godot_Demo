using Components_Namespace;
using Core;

namespace Commands;

public record Shield_Action_Command(Components Action, Components Target)
    : Command
{
}
