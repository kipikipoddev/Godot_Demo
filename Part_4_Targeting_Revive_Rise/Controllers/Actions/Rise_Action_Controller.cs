using Commands;
using Components_Namespace;
using Core;

namespace Controllers;

public class Rise_Action_Controller
{
    public Rise_Action_Controller()
    {
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static void Do_Action_Handler(Do_Action_Command cmd)
    {
        var comp = cmd.Action.Get<Rise_Action_Component>();
        if (comp != null)
            cmd.Target.Get<Group_Component>().Group = cmd.Action.Parent.Group();
    }
}