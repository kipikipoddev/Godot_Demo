using Core;

namespace Components_Namespace;

public static class Armor_Component
{
    private static readonly string Key = "Armor_Component";

    public static Components Set_Armor(this Components comp, int armor)
    {
        comp.Set(Key, armor);
        return comp;
    }

    public static int Get_Armor(this Components comp)
    {
        return comp.Get<int>(Key);
    }
}