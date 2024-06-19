using Core;

namespace Commands;

public record Do_Action_Command(Components Action, Components Target) : Command
{
}
