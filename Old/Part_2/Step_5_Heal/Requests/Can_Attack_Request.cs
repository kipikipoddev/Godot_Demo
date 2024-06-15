using Core;
using Models;

namespace Messages;

public record Can_Attack_Request(Attack_Model Model, Entity_Model Target)
    : Request<Can_Attack_Request, bool>
{
}
