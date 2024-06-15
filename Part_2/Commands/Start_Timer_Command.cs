using Core;

namespace Commands;

public record Start_Timer_Command(Ranged_Value<double> Timer) : Command
{
}
