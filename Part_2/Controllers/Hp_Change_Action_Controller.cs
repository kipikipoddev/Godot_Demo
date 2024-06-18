using Commands;
using Components_Namespace;
using Core;
using Requests;

namespace Controllers;

public class Hp_Change_Action_Controller
{
    public Hp_Change_Action_Controller()
    {
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static void Do_Action_Handler(Do_Action_Command command)
    {
        var comp = command.Action.Get<Hp_Change_Action_Component>();
        if (comp != null)
            new Hp_Change_Command(command.Action, command.Target, comp.Is_Positive);
    }
}