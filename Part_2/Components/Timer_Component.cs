using Commands;
using Core;

namespace Components_Namespace;

public record Timer_Component : Component
{
    public Ranged_Value<double> Time { get; }
    public bool In_Progress => Time.Value > 0;
    public bool Ended => Time.Value <= 0;

    public Timer_Component(int time)
    {
        Time = new(0, 0, time);
    }

    public void Start()
    {
        Time.Value = Time.Max;
        new Start_Timer_Command(this);
    }
}

public static class Components_Timer_Extension
{
    public static Timer_Component Timer(this Components components)
    {
        return components.Get<Timer_Component>();
    }
}