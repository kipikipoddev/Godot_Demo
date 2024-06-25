using System.Collections.Generic;
using Commands;
using Core;
using Data;
using Messages;
using Models;
using Requests;

namespace Controllers;

public class Action_Controller
{
    private readonly List<Casting_Data> casting;

    public Action_Controller()
    {
        casting = new();
        Mediator.Add_Listener<Update_Message>(Update_Handler);
        Mediator.Add_Listener<Start_Action_Command>(Start_Action_Handler);
    }

    private void Start_Action_Handler(Start_Action_Command cmd)
    {
        cmd.Action.Cooldown.Start();
        var timer = new Timer_Model(cmd.Action.Cast_Time);
        cmd.Action.Owner.Casting = timer;
        casting.Add(new Casting_Data(cmd, timer));
    }

    private void Update_Handler(Update_Message message)
    {
        for (int i = 0; i < casting.Count; i++)
        {
            var can_action = Can_Action(casting[i]);
            if (!can_action)
            {
                casting[i].Casting.Value = 0;
                casting.RemoveAt(i);
            }
            else if (casting[i].Casting.Is_Min)
            {
                new Do_Action_Command(casting[i].Action, casting[i].Target);
                casting.RemoveAt(i);
                i = -1;
            }
        }
    }

    private bool Can_Action(Casting_Data data)
    {
        return new Can_Action_Request(data.Action, data.Target, false).Result;
    }

}