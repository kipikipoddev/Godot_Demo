using Components_Namespace;
using Core;

namespace Commands;

public record Start_Timer_Command(Timer_Component Timer) : Command
{
}
