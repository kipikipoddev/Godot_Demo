using Components_Namespace;
using Core;

namespace Requests;

public record Can_Action_Request(Action_Components Action, Components Target)
    : Request<bool>
{
}
