using System.Collections.Generic;
using Commands;
using Components_Namespace;
using Messages;

namespace Controllers;

public class Timer_Controller
{
    private readonly List<Timer_Component> timers;

    public Timer_Controller()
    {
        timers = new();
        Start_Timer_Command.Handler = Start_Timer_Command_Handler;
        Time_Message.Handle(Time_Message_Handler);
    }

    private void Start_Timer_Command_Handler(Start_Timer_Command cmd)
    {
        if (!timers.Contains(cmd.Component))
            timers.Add(cmd.Component);
    }

    private void Time_Message_Handler(Time_Message msg)
    {
        for (int i = 0; i < timers.Count; i++)
        {
            timers[i].Time.Value -= msg.Delta;
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