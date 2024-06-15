using System;
using Core;

namespace Components_Namespace;

public static class Do_Action_Component
{
    private static readonly string Key = "Do_Action_Component";

    public static Components Set_Do_Action(this Components comp, Action<Components> action)
    {
        comp.Set(Key, action);
        return comp;
    }

    public static Action<Components> Get_Do_Action(this Components comp)
    {
        return comp.Get<Action<Components>>(Key);
    }
}