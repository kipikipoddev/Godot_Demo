using Components_Namespace;
using Core;

namespace Commands;

public record Over_Time_Command(Action_Components Action, Components Target)
    : Command
{
}
