using Core;
using Resources;

namespace Requests;

public record Create_Action_Request(Action_Resource Resource)
    : Request<Components>
{
}
