using System;
using Core;

namespace Components_Namespace;

public record Do_Action_Component(Action<Components> Action) : Component
{
}

public static class Components_Do_Action_Extension
{
    public static void Action(this Components components,Components arg)
    {
        components.Get<Do_Action_Component>().Action(arg);
    }
}
