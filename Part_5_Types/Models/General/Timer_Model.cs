using Commands;
using Interfaces;

namespace Models;

public class Timer_Model : ITimer_Model
{
    public double Current { get; set; }
    public double Interval { get; }
    public Timer_Model(int interval)
    {
        Interval = interval;
        Start();
    }

    public void Start()
    {
        new Start_Timer_Command(this);
    }
}