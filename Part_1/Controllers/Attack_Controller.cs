using Commands;
using Components_Namespace;
using Messages;
using Singletons;

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
        return request.Target.Hp().Not_Min & request.Attack.Parent.Hp().Not_Min;
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Target.Hp().Value -= command.Attack.Amount();
    }
}