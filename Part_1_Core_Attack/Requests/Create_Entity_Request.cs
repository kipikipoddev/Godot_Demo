using Core;
using Resources;

namespace Requests;

public record Create_Entity_Request(Entity_Resource Resource)
    : Request<Components>
{
}
