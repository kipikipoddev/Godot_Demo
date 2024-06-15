using Core;
using Commands;
using Components_Namespace;
using Messages;

namespace Controllers;

public class Attack_Controller
{
    public Attack_Controller()
    {
        Mediator.Add_Listener<Attack_Command>(Attack_Command_Handler);
        Mediator.Set_Handler<Can_Attack_Request, bool>(Can_Attack_Request_Handler);
    }

    private bool Can_Attack_Request_Handler(Can_Attack_Request request)
    {
        return request.Target.Get_Hp().Not_Min & request.Attack.Parent.Get_Hp().Not_Min;
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Target.Get_Hp().Value -= command.Attack.Get_Amount();
    }
}