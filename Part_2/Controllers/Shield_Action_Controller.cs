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
    private static void Do_Action_Handler(Do_Action_Command command)
    {
        if (!command.Action.Has<Shield_Action_Component>())
            return;
        var amount = command.Action.Amount().Amount;
        command.Target.Set(new Shield_Component(amount));
    }
}