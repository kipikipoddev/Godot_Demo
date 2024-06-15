using Commands;
using Messages;

namespace Controllers;

public class Attack_Controller
{
    public Attack_Controller()
    {
        Attack_Command.Handle(Attack_Command_Handler);
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Target.Hp.Value -= command.Model.Damage;
        new Update_Message();
    }
}
