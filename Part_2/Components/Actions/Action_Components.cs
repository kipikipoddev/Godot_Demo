using Core;
using Requests;
using Resources;

namespace Components_Namespace;

public abstract record Action_Components : Components
{
    public Action_Components(Action_Resource resource)
    {
        Set(new Name_Component(resource.Name));
        Set(new Timer_Component(resource.Cooldown));
    }

    public bool Can(Components target)
    {
        return new Can_Action_Request(this, target).Result;
    }

    public abstract void Do(Components target);
}