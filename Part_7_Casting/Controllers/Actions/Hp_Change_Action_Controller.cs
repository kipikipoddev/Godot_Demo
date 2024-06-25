using Commands;
using Models;
using Core;
using Interfaces;
using System;
using System.Linq;

namespace Controllers;

public class Hp_Change_Action_Controller
{
    public Hp_Change_Action_Controller()
    {
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static void Do_Action_Handler(Do_Action_Command cmd)
    {
        if (cmd.Action is Hp_Change_Action_Model hp_change)
        {
            var hp_cmd = new Hp_Change_Command(hp_change, cmd.Target);
            if (cmd.Action is IOver_Timer_Model over_time_model)
                new Over_Time_Command(over_time_model, hp_cmd, Get_Can_Run(cmd.Target));
        }
    }

    private static Func<bool> Get_Can_Run(IEntity_Model target)
    {
        return () => 
            target.Is_Alive & !target.Effects.Any(e => e is Stasis_Model);
    }
}