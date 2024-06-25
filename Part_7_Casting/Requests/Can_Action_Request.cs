using Core;
using Interfaces;

namespace Requests;

public record Can_Action_Request(IAction_Model Action, IEntity_Model Target, bool Start_Casting)
    : Request<bool>
{
}
