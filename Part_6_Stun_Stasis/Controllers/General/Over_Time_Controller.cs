using System.Collections.Generic;
using System.Linq;
using Commands;
using Core;
using Data;
using Messages;

namespace Controllers;

public class Over_Time_Controller
{
    private readonly List<Over_Time_Data> over_time_datas;

    public Over_Time_Controller()
    {
        over_time_datas = new();
        Mediator.Add_Listener<Over_Time_Command>(Over_Time_Handler);
        Mediator.Add_Listener<Update_Message>(Update_Handler);
    }

    private void Update_Handler(Update_Message msg)
    {
        for (int i = 0; i < over_time_datas.Count; i++)
        {
            if (!over_time_datas[i].Command.Can_Run())
                over_time_datas.RemoveAt(i);
            else if (over_time_datas[i].Timer.Ended)
                Run(over_time_datas[i]);
        }
    }
    private void Run(Over_Time_Data data)
    {
        data.Command.Command.Invoke();
        if (--data.Runs_Left == 0)
            over_time_datas.Remove(data);
        else
            data.Timer.Start();
    }

    private void Over_Time_Handler(Over_Time_Command cmd)
    {
        var existing = over_time_datas.FirstOrDefault(o => o.Command.Model.Name == cmd.Model.Name);
        if (existing != null)
        {
            existing.Timer.Start();
            existing.Runs_Left = cmd.Model.Times - 1;
        }
        else
            over_time_datas.Add(new Over_Time_Data(cmd));
    }
}