using Core;
using Interfaces;
using Models;

namespace Messages;

public record Can_Attack_Request(Action_Model Model, IHp_Model Target)
    : Request<Can_Attack_Request, bool>
{
}
