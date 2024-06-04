using Commands;
using Interfaces;

namespace Models;

public class Timer_Model : ITimer_Model
{
    public int Time { get; }
    public double Current { get; set; }

    public Timer_Model(int time, bool auto_start = true)
    {
        Time = time;
        if (auto_start)
            Start();
    }

    public void Start()
    {
        Current = Time;
        new Start_Timer_Command(this);
    }
}