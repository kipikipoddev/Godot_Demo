using Core;
using Interfaces;
using Models;

namespace Messages;

public record Can_Heal_Request(Action_Model Model, IHp_Model Target)
    : Request<Can_Heal_Request, bool>
{
}
