using Components_Namespace;
using Core;
using Interfaces;

namespace Commands;

public record Over_Time_Command(IOvertime_Model Overtime, Command Command, IHp_Model Target)
    : Command
{
}
