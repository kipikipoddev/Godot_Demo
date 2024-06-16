using Core;
using Interfaces;

namespace Requests;

public record Can_Action_Request(IAction_Model Action, IHp_Model Target)
    : Request<bool>
{
}
