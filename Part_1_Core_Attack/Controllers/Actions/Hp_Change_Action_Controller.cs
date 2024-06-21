using Commands;
using Models;
using Core;

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
            new Hp_Change_Command(hp_change, cmd.Target);
    }
}