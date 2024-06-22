using Core;
using Interfaces;

namespace Commands;

public record Do_Action_Command(IAction_Model Action, IEntity_Model Target) : Command
{
}
