using Components_Namespace;
using Core;

namespace Messages;

public record Can_Action_Request(Components Model, Components Target)
    : Request<Can_Action_Request, bool>
{
}
