using Commands;

namespace Models;

public class Timer_Model
{
    public int Time { get; }
    public double Current { get; set; }
    public bool In_Progress => Current > 0;
    public bool Ended => !In_Progress;

    public Timer_Model(int time)
    {
        Time = time;
        Start();
    }

    public void Start()
    {
        Current = Time;
        new Start_Timer_Command(this);
    }
}