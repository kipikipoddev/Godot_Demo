using Core;
using Resources;

namespace Requests;

public record Create_Entity_Request(Entity_Resource Resource, int Group)
    : Request<Components>
{
}
