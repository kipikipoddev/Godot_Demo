using System;
using Core;

namespace Components_Namespace;

public class Do_Action_Component : Component
{
    private readonly Action<Components> do_action;

    public Do_Action_Component(Action<Components> do_action)
    {
        this.do_action = do_action;
    }

    public void Do(Components component)
    {
        do_action(component);
    }
}