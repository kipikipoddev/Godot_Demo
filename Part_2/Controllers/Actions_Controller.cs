using Commands;
using Components_Namespace;
using Core;
using Requests;

namespace Controllers;

public class Actions_Controller
{
    public Actions_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Action_Command>(Hp_Change_Action_Handler);
        Mediator.Set_Handler<Can_Action_Request, bool>(Can_Attack_Handler);
        Mediator.Add_Listener<Shield_Action_Command>(Shield_Handler);
    }

    private bool Can_Attack_Handler(Can_Action_Request request)
    {
        return request.Target != null
            && request.Target.Hp().Is_Alive
            && request.Action.Parent.Hp().Is_Alive
            && request.Action.Timer().Ended;
    }

    private void Hp_Change_Action_Handler(Hp_Change_Action_Command command)
    {
        var action = command.Action;
        action.Timer().Start();
        var cmd = new Hp_Change_Command(command.Target, action.Amount(), action.Is_Positive());
        var over_time = action.Get<Over_Time_Component>();
        if (over_time != null)
            new Over_Time_Command(action, cmd, command.Target);
    }

    private void Shield_Handler(Shield_Action_Command command)
    {
        command.Action.Timer().Start();
        command.Target.Set(new Shield_Component(command.Action.Amount()));
    }
}