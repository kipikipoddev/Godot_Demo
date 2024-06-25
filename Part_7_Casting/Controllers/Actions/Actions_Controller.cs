using Commands;
using Models;
using Core;

namespace Controllers;

public class Actions_Controller
{
    public Actions_Controller()
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
        else if (cmd.Action is Revive_Action_Model revive)
        {
            cmd.Target.Hp.Value = revive.To_Hp;
        }
        else if (cmd.Action is Rise_Action_Model rise)
        {
            cmd.Target.Hp.Value = rise.To_Hp;
            cmd.Target.Group = rise.Owner.Group;
        }
    }
}