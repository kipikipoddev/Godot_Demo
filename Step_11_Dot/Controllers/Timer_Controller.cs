using System.Collections.Generic;
using Commands;
using Messages;
using Models;

namespace Controllers;

public class Timer_Controller
{
    private readonly List<Timer_Model> timers;

    public Timer_Controller()
    {
        timers = new List<Timer_Model>();
        Start_Timer_Command.Handle(Start_Timer_Command_Handler);
        Time_Message.Handle(Time_Message_Handler);
    }

    private void Start_Timer_Command_Handler(Start_Timer_Command cmd)
    {
        if (!timers.Contains(cmd.Model))
            timers.Add(cmd.Model);
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