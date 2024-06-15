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
        Mediator.Add_Listener<Shield_Command>(Shield_Handler);
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
        Start(command.Action);
        new Damage_Command(command.Target, command.Action.Amount());
        if (command.Action.Has<Over_Time_Component>())
            new Over_Time_Command(command.Action, command.Target);
    }

    private void Heal_Handler(Heal_Command command)
    {
        Start(command.Action);
        command.Target.Hp().Value += command.Action.Amount();
        if (command.Action.Has<Over_Time_Component>())
            new Over_Time_Command(command.Action, command.Target);
    }

    private void Shield_Handler(Shield_Command command)
    {
        Start(command.Action);
        command.Target.Set(new Shield_Component(command.Action.Amount()));
    }

    private static void Start(Components components)
    {
        components.Timer().Start();
    }
}