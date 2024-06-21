using Commands;
using Models;
using Core;
using Interfaces;

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
            Handle_Over_Time(cmd, hp_cmd);
        }
    }

    private static void Handle_Over_Time(Do_Action_Command cmd, Hp_Change_Command hp_cmd)
    {
        if (cmd.Action is IOver_Timer_Model over_timer)
            new Over_Time_Command(over_timer, hp_cmd, () => cmd.Target.Is_Alive);
    }
}