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
            target.Get<Hp_Component>().Is_alive &
            action.Owner.Get<Hp_Component>().Is_alive &
            !action.Get<Timer_Component>().In_Progress;
    }

    private bool Can_Attack_Request_Handler(Can_Action_Request request)
    {
        return Can_Action(request.Model, request.Target);
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Entity.Get<Timer_Component>().Start();
        new Damage_Command(command.Target, command.Entity.Get<Amount_Component>().Amount);
    }

    private void Heal_Command_Handler(Heal_Command command)
    {
        command.Entity.Get<Timer_Component>().Start();

        var amount = command.Entity.Get<Amount_Component>().Amount;
        var hp = command.Target.Get<Hp_Component>().Hp;
        hp.Value += amount;
    }

    private void Shield_Command_Handler(Shield_Command command)
    {
        command.Action.Get<Timer_Component>().Start();
        var amount = command.Action.Get<Amount_Component>().Amount;
        command.Target.Add(new Shield_Component(amount));
    }
}