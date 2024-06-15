using Core;

namespace Requests;

public record Can_Attack_Request(Components Attack, Components Target)
    : Request<bool>
{
}
