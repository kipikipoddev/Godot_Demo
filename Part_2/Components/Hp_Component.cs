using Core;

namespace Components_Namespace;

public static class Hp_Component
{
    private static readonly string Key = "Hp_Component";

    public static Components Set_Hp(this Components comp, int hp)
    {
        comp.Set(Key, new Ranged_Value<int>(hp, 0, hp));
        return comp;
    }

    public static Ranged_Value<int> Get_Hp(this Components comp)
    {
        return comp.Get<Ranged_Value<int>>(Key);
    }
}