using Core;
using Models;

namespace Messages;

public record Can_Heal_Request(Heal_Model Model, Entity_Model Target)
    : Request<Can_Heal_Request, bool>
{
}
