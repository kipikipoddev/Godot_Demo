using Core;
using Resources;

namespace Requests;

public record Build_Entity_Request(Entity_Resource Resource)
    : Request<Components>
{
}
