using Commands;
using Components_Namespace;
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
        var comp = cmd.Action.Get<Hp_Change_Action_Component>();
        if (comp != null)
            new Hp_Change_Command(cmd.Target, comp.Amount);
    }
}