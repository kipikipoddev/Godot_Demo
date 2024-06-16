using Components_Namespace;
using Core;

namespace Commands;

public record Hp_Change_Action_Command(Components Action, Components Target)
    : Command
{
}
