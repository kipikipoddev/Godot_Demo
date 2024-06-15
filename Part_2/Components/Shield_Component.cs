using Core;

namespace Components_Namespace;

public static class Shield_Component
{
    private static readonly string Key = "Shield_Component";

    public static Components Set_Shield(this Components comp, int shield)
    {
        comp.Set(Key, new Ranged_Value<int>(shield, 0, shield));
        return comp;
    }

    public static Ranged_Value<int> Get_Shield(this Components comp)
    {
        return comp.Get<Ranged_Value<int>>(Key);
    }

    public static void Remove_Shield(this Components comp)
    {
        comp.Clear(Key);
    }
}