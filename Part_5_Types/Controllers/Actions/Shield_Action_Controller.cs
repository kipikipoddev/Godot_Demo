using Commands;
using Components_Namespace;
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
        var comp = cmd.Action.Get<Shield_Action_Component>();
        if (comp != null)
            cmd.Target.Set(new Shield_Component(cmd.Action.Amount().Amount));
    }
}