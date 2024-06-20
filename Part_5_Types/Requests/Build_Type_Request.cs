using Components_Namespace;
using Core;
using Resources;

namespace Requests;

public record Build_Type_Request(Type_Resource Resource)
    : Request<Type_Component>
{
}
