using System;
using Core;

namespace Components_Namespace;

public class Can_Action_Component : Component
{
    private readonly Func<Components, bool> can_do_action;

    public Can_Action_Component(Func<Components, bool> can_do_action)
    {
        this.can_do_action = can_do_action;
    }

    public bool Can_Do(Components component)
    {
        return can_do_action(component);
    }
}