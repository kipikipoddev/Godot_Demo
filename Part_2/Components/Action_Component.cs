using System.Collections.Generic;
using Core;

namespace Components_Namespace;

public static class Action_Component
{
    private static readonly string Key = "Action_Component";

    public static Components Add_Action(this Components comp, Components action)
    {
        comp.Add(Key, action);
        return comp;
    }

    public static IEnumerable<Components> Get_Actions(this Components comp)
    {
        return comp.Get_All<Components>(Key);
    }
}