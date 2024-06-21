using Commands;
using Core;
using Requests;

namespace Controllers;

public class Action_Controller
{
    public Action_Controller()
    {
        Mediator.Add_Handler<Can_Action_Request, bool>(Can_Action_Handler);
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static bool Can_Action_Handler(Can_Action_Request req)
    {
        return req.Target != null
            && req.Target.Is_Alive
            && req.Action.Owner.Is_Alive;
    }

    private static void Do_Action_Handler(Do_Action_Command cmd)
    {

    }
}