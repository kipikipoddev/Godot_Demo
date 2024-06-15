using Commands;
using Core;

namespace Components_Namespace;

public static class Timer_Component
{
    private static readonly string Key = "Timer_Component";

    public static Components Set_Timer(this Components comp, int time)
    {
        comp.Set(Key, new Ranged_Value<double>(0, 0, time));
        return comp;
    }

    public static Ranged_Value<double> Get_Timer(this Components comp)
    {
        return comp.Get<Ranged_Value<double>>(Key);
    }

    public static void Start_Timer(this Components comp)
    {
        var timer = comp.Get<Ranged_Value<double>>(Key);
        new Start_Timer_Command(timer);
    }
}