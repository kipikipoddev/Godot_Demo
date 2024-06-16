using Core;
using Resources;

namespace Components_Namespace;

public record Entity_Components : Components
{
    public Entity_Components(Entity_Resource resource)
    {
        Set(new Name_Component(resource.Name));
        Set(new Hp_Component(resource.Hp));
        Set(new Attack_Components(resource.Attack));
    }
}