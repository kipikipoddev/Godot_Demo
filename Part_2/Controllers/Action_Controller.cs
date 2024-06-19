using Commands;
using Components_Namespace;
using Core;
using Requests;

namespace Controllers;

public class Action_Controller
{
    public Action_Controller()
    {
        Mediator.Add_Listener<Can_Action_Request, bool>(Can_Action_Handler);
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static bool Can_Action_Handler(Can_Action_Request request)
    {
        return request.Target != null
            && request.Target.Hp().Is_Alive
            && request.Action.Parent.Hp().Is_Alive
            && request.Action.Timer().Ended;
    }

    private static void Do_Action_Handler(Do_Action_Command command)
    {
        command.Action.Timer().Start();
    }
}