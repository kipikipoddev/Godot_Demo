
using Components_Namespace;
using Core;

namespace Commands;

public record Over_Time_Command(Components Action, Command Command, Components Target)
    : Command
{
}
