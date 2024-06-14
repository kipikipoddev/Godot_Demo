using Core;

namespace Components_Namespace;

public class Over_Time_Component : Component
{
    public int Time_between { get; }
    public int Times { get; }
    public bool Is_heal { get; }


    public Over_Time_Component(int time_between, int times, bool is_heal)
    {
        Time_between = time_between;
        Times = times;
        Is_heal = is_heal;
    }
}