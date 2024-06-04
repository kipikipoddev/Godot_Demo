using Commands;
using Messages;

namespace Controllers;

public class Attack_Controller
{
    public Attack_Controller()
    {
        Attack_Command.Handle(Attack_Command_Handler);
        Can_Attack_Request.Handler = Can_Attack_Request_Handler;
    }

    private bool Can_Attack_Request_Handler(Can_Attack_Request request)
    {
        return request.Target.Is_Alive & request.Attack.Owner.Is_Alive;
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Target.Hp.Value -= command.Model.Damage;
        new Update_Message();
    }
}