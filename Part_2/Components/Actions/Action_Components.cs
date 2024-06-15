using Core;
using Requests;

namespace Components_Namespace;

public abstract record Action_Components : Components
{
    public Action_Components(string name, int cooldown)
    {
        Set(new Name_Component(name));
        Set(new Timer_Component(cooldown));
    }

    public bool Can(Components target)
    {
        return new Can_Action_Request(this, target).Result;
    }

    public abstract void Do(Components target);
}