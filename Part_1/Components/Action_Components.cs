using Core;
using Requests;
using Resources;

namespace Components_Namespace;

public abstract record Action_Components : Components
{
    public Action_Components(Named_Resource resource)
    {
        Set(new Name_Component(resource.Name));
    }

    public bool Can(Components target)
    {
        return new Can_Action_Request(this, target).Result;
    }

    public abstract void Do(Components target);
}