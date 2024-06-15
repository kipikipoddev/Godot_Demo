using Core;
using Interfaces;
using Resources;

namespace Messages;

public record Create_Entity_Model_Request(Entity_Resource Resource)
    : Request<Create_Entity_Model_Request, IEntity_Model>
{
}
