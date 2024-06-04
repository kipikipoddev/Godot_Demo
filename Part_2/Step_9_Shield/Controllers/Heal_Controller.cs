using Commands;
using Messages;

namespace Controllers;

public class Heal_Controller : Action_Controller
{
    public Heal_Controller()
    {
        Heal_Command.Handler = Heal_Command_Handler;
        Can_Heal_Request.Handler = Can_Heal_Request_Handler;
        Shield_Command.Handle(Shield_Command_Handler);
    }

    private bool Can_Heal_Request_Handler(Can_Heal_Request request)
    {
        return Can_Action(request.Model, request.Target);
    }

    private void Heal_Command_Handler(Heal_Command command)
    {
        command.Model.Cooldown.Start();
        command.Target.Hp.Value += command.Model.Heal;
    }

    private void Shield_Command_Handler(Shield_Command command)
    {
        command.Model.Cooldown.Start();
        command.Target.Shield.Max = command.Model.Amount;
        command.Target.Shield.Value = command.Model.Amount;
        new Update_Message();
    }
}