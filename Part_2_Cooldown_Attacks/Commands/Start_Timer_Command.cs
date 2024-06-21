using Models;
using Core;

namespace Commands;

public record Start_Timer_Command(Timer_Model Timer) : Command
{
}
