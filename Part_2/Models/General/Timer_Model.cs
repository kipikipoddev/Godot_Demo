using Commands;
using Core;
using Interfaces;

namespace Models;

public class Timer_Model : ITimer_Model
{
    public Ranged_Value<double> Time { get; }

    public Timer_Model(int time)
    {
        Time = new(0, 0, time);
        Start();
    }

    public void Start()
    {
        Time.Value = Time.Max;
        new Start_Timer_Command(this);
    }
}