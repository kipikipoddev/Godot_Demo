using Core;
using Resources;

namespace Messages;

public record Create_Entity_Request(Entity_Resource Resource) : Request<Components>
{
}
