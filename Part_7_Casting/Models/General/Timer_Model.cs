using Commands;
using Interfaces;

namespace Models;

public class Timer_Model : Doubel_Model, ITimer_Model
{
    public bool Is_Paused { get; set; }

    public Timer_Model(int interval)
        : base(interval)
    {
        Start();
    }

    public void Start()
    {
        new Start_Timer_Command(this);
    }
}