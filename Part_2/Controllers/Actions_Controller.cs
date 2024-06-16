using Commands;
using Components_Namespace;
using Core;
using Requests;

namespace Controllers;

public class Actions_Controller
{
    public Actions_Controller()
    {
        Mediator.Add_Listener<Attack_Command>(Attack_Handler);
        Mediator.Set_Handler<Can_Action_Request, bool>(Can_Attack_Handler);
        Mediator.Add_Listener<Heal_Command>(Heal_Handler);
        Mediator.Add_Listener<Shield_Action_Command>(Shield_Handler);
    }

    private bool Can_Attack_Handler(Can_Action_Request request)
    {
        return request.Target != null
            && request.Target.Hp().Not_Min
            && request.Action.Parent.Hp().Not_Min
            && request.Action.Timer().Ended;
    }

    private void Attack_Handler(Attack_Command command)
    {
        Hp_Change_Command(command.Attack, command.Target, false);
    }

    private void Heal_Handler(Heal_Command command)
    {
        Hp_Change_Command(command.Heal, command.Target, true);
    }

    private void Shield_Handler(Shield_Action_Command command)
    {
        command.Action.Timer().Start();
        command.Target.Set(new Shield_Component(command.Action.Amount()));
    }

    private void Hp_Change_Command(Action_Components action, Components target, bool is_positive)
    {
        action.Timer().Start();
        var cmd = new Hp_Change_Command(target, action.Amount(), is_positive);
        if (action.Has<Over_Time_Component>())
            new Over_Time_Command(action, cmd, target);
    }
}