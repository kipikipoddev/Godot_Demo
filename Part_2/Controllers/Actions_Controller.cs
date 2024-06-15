using Commands;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Actions_Controller
{
    public Actions_Controller()
    {
        Mediator.Add_Listener<Attack_Command>(Attack_Command_Handler);
        Mediator.Set_Handler<Can_Action_Request, bool>(Can_Attack_Request_Handler);
        Mediator.Add_Listener<Heal_Command>(Heal_Command_Handler);
        Mediator.Add_Listener<Shield_Command>(Shield_Command_Handler);
    }

    private bool Can_Attack_Request_Handler(Can_Action_Request request)
    {
        return request.Target != null &&
            request.Target.Get_Hp().Not_Min &
            request.Action.Parent.Get_Hp().Not_Min &
            !request.Action.Get_Timer().In_Progress;
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Entity.Get_Timer().Start();
        new Damage_Command(command.Target, command.Entity.Get_Amount());
    }

    private void Heal_Command_Handler(Heal_Command command)
    {
        command.Entity.Get_Timer().Start();
        var amount = command.Entity.Get_Amount();
        command.Target.Get_Hp().Value += amount;
    }

    private void Shield_Command_Handler(Shield_Command command)
    {
        command.Action.Get_Timer().Start();
        command.Target.Set_Shield(command.Action.Get_Amount());
    }
}