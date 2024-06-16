using Components_Namespace;
using Core;

namespace Requests;

public record Can_Action_Request(Components Action, Components Target)
    : Request<bool>
{
}
