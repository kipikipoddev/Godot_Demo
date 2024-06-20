using System.Collections.Generic;
using Commands;
using Core;
using Requests;

namespace Components_Namespace;

public record Action_Component : Component
{
    public bool Can(Components target)
    {
        return new Can_Action_Request(Parent, target).Result;
    }

    public void Do(Components target)
    {
        new Do_Action_Command(Parent, target);
    }
}

public static class Action_Extensions
{
    public static Action_Component Action(this Components components)
    {
        return components.Get<Action_Component>();
    }

    public static IEnumerable<Action_Component> Get_Actions(this Components components)
    {
        return components.Get_Has<Action_Component>();
    }
}