using Core;
using Resources;

namespace Requests;

public record Build_Action_Request(Action_Resource Resource)
    : Request<Components>
{
}
