using Commands;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Actions_Controller
{
    public Actions_Controller()
    {
        Attack_Command.Handler = Attack_Command_Handler;
        Can_Action_Request.Handler = Can_Attack_Request_Handler;
        Heal_Command.Handler = Heal_Command_Handler;
        Shield_Command.Handler = Shield_Command_Handler;
    }

    private bool Can_Action(Components action, Components target)
    {
        return target != null &&
            target.Hp().Not_Min &
            action.Owner.Hp().Not_Min &
            !action.Timer().In_Progress;
    }

    private bool Can_Attack_Request_Handler(Can_Action_Request request)
    {
        return Can_Action(request.Model, request.Target);
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Entity.Timer().Start();
        new Damage_Command(command.Target, command.Entity.Amount());
    }

    private void Heal_Command_Handler(Heal_Command command)
    {
        command.Entity.Timer().Start();
        var amount = command.Entity.Amount();
        command.Target.Hp().Value += amount;
    }

    private void Shield_Command_Handler(Shield_Command command)
    {
        command.Action.Timer().Start();
        command.Target.Add(new Shield_Component(command.Action.Amount()));
    }
}