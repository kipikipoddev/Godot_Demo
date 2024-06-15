using System;
using Core;

namespace Components_Namespace;

public record Can_Action_Component(Func<Components, bool> Can_Do_Action) : Component
{
}

public static class Components_Can_Do_Action_Extension
{
    public static bool Can_Do_Action(this Components components, Components arg)
    {
        return components.Get<Can_Action_Component>().Can_Do_Action(arg);
    }
}