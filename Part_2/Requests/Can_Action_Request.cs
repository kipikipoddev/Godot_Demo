using Core;

namespace Messages;

public record Can_Action_Request(Components Action, Components Target)
    : Request<bool>
{
}
