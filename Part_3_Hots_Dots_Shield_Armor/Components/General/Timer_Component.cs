using Commands;
using Core;

namespace Components_Namespace;

public record Timer_Component : Component
{
    public double Current { get; set; }
    public double Interval { get; }
    public bool In_Progress => Current > 0;
    public bool Ended => Current <= 0;

    public Timer_Component(int interval)
    {
        Interval = interval;
        Start();
    }

    public void Start()
    {
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