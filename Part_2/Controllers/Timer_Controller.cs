using System.Collections.Generic;
using Commands;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Timer_Controller
{
    private readonly List<Timer_Component> timers;

    public Timer_Controller()
    {
        timers = new();
        Mediator.Add_Listener<Start_Timer_Command>(Start_Timer_Command_Handler);
        Mediator.Add_Listener<Time_Message>(Time_Message_Handler);
    }

    private void Start_Timer_Command_Handler(Start_Timer_Command cmd)
    {
        cmd.Timer.Current = cmd.Timer.Interval;
        if (!timers.Contains(cmd.Timer))
            timers.Add(cmd.Timer);
    }

    private void Time_Message_Handler(Time_Message msg)
    {
        for (int i = 0; i < timers.Count; i++)
        {
            timers[i].Current -= msg.Delta;
            if (timers[i].Ended)
            {
                new Update_Message();
                if (timers[i].Ended)
                {
                    timers.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}