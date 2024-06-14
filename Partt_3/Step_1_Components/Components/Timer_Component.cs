using Commands;
using Core;

namespace Components_Namespace;

public class Timer_Component : Component
{
    public Ranged_Value<double> Time { get; }
    public bool In_Progress => Time.Value > 0;
    public bool Ended => Time.Value <= 0;

    public Timer_Component(int time, bool auto_start = true)
    {
        Time = new(0, 0, time);
        if (auto_start)
            Start();
    }

    public void Start()
    {
        Time.Value = Time.Max;
        new Start_Timer_Command(this);
    }
}