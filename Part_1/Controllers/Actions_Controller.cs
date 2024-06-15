using Core;
using Commands;
using Components_Namespace;
using Requests;

namespace Controllers;

public class Actions_Controller
{
    public Actions_Controller()
    {
        Mediator.Add_Listener<Attack_Command>(Attack_Handler);
        Mediator.Set_Handler<Can_Action_Request, bool>(Can_Action_Handler);
    }

    private bool Can_Action_Handler(Can_Action_Request request)
    {
        return request.Target.Hp().Not_Min
            && request.Action.Parent.Hp().Not_Min;
    }

    private void Attack_Handler(Attack_Command command)
    {
        command.Target.Hp().Value -= command.Attack.Amount();
    }
}