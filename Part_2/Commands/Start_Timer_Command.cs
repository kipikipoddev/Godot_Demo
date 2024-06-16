using Core;
using Interfaces;

namespace Commands;

public record Start_Timer_Command(ITimer_Model Timer) : Command
{
}
