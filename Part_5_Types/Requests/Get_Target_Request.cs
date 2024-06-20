using Components_Namespace;
using Core;

namespace Messages;

public record Get_Target_Request(Action_Component Action)
    : Request<Components>
{
}