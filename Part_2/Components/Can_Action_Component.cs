using System;
using Core;

namespace Components_Namespace;

public static class Can_Action_Component
{
    private static readonly string Key = "Can_Action_Component";

    public static Components Set_Can_Action(this Components comp, Func<Components, bool> Can_Action)
    {
        comp.Set(Key, Can_Action);
        return comp;
    }

    public static Func<Components, bool> Get_Can_Action(this Components comp)
    {
        return comp.Get<Func<Components, bool>>(Key);
    }
}