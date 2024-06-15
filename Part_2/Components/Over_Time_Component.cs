using Core;
using Data;

namespace Components_Namespace;

public static class Over_Time_Component
{
    private static readonly string Key = "Over_Time_Component";

    public static Components Set_Over_Time(this Components comp, Over_Time_Data model)
    {
        comp.Set(Key, model);
        return comp;
    }

    public static Over_Time_Data Get_Over_Time(this Components comp)
    {
        return comp.Get<Over_Time_Data>(Key);
    }
}