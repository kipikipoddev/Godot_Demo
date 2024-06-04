using System.Collections.Generic;
using Commands;
using Messages;
using Models;

namespace Controllers;

public class Timer_Controller
{
    private readonly List<Timer_Model> models;

    public Timer_Controller()
    {
        models = new List<Timer_Model>();
        Start_Timer_Command.Handle(c => models.Add(c.Model));
        Time_Message.Handle(Time_Message_Handler);
    }

    private void Time_Message_Handler(Time_Message message)
    {
        for (int i = 0; i < models.Count; i++)
        {
            models[i].Current -= message.Delta;
            if (models[i].Ended)
            {
                new Update_Message();
                models.RemoveAt(i);
                i--;
            }
        }
    }
}