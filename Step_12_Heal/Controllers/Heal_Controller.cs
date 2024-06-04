using Commands;
using Messages;

namespace Controllers;

public class Heal_Controller
{
    public Heal_Controller()
    {
        Heal_Command.Handle(Heal_Command_Handler);
        Can_Heal_Request.Handler = Can_Heal_Request_Handler;
    }

    private bool Can_Heal_Request_Handler(Can_Heal_Request request)
    {
        return request.Target != null &&
            request.Target.Is_Alive &
            request.Model.Owner.Is_Alive &
            request.Model.Cooldown.Ended;
    }

    private void Heal_Command_Handler(Heal_Command command)
    {
        command.Model.Cooldown.Start();
        command.Target.Hp.Value += command.Model.Heal;
        new Update_Message();
    }
}