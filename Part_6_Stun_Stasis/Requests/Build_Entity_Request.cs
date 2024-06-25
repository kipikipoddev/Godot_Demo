using Core;
using Interfaces;
using Resources;

namespace Requests;

public record Create_Entity_Request(Entity_Resource Resource, Group_Resource Group)
    : Request<IEntity_Model>
{
}
