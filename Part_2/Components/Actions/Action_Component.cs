using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using Requests;

namespace Components_Namespace;

public abstract record Action_Component : Component
{
    public bool Can(Components target)
    {
        return new Can_Action_Request(Parent, target).Result;
    }

    public abstract void Do(Components target);
}

public static class Action_Extensions
{
    public static IEnumerable<Action_Component> Get_Actions(this Components components)
    {
        return components.Get_All<Components>()
            .Where(c => c.Has<Action_Component>())
            .Select(c => c.Get<Action_Component>());
    }
}