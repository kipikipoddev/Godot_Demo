using Core;

namespace Components_Namespace;

public static class Amount_Component
{
    private static readonly string Key = "Amount_Component";

    public static Components Set_Amount(this Components comp, int amount)
    {
        comp.Set(Key, amount);
        return comp;
    }

    public static int Get_Amount(this Components comp)
    {
        return comp.Get<int>(Key);
    }
}