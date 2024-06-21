using Commands;
using Models;
using Core;

namespace Controllers;

public class Shield_Action_Controller
{
    public Shield_Action_Controller()
    {
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static void Do_Action_Handler(Do_Action_Command cmd)
    {
        if (cmd.Action is Shield_Action_Model shield)
        {
            cmd.Target.Shield.Max = shield.Amount;
            cmd.Target.Shield.Value = shield.Amount;
        }
    }
}