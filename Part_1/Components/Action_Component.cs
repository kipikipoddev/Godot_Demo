using Core;
using Requests;

namespace Components_Namespace;

public abstract record Action_Component : Components
{
    public bool Can(Components target)
    {
        return new Can_Action_Request(this, target).Result;
    }

    public abstract void Do(Components target);
}