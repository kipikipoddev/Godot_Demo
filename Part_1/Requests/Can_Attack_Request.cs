using Core;

namespace Messages;

public record Can_Attack_Request(Components Attack, Components Target)
    : Request<bool>
{
}
