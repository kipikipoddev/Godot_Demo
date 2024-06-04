using Commands;
using Messages;

namespace Controllers;

public class Entity_Controller
{
    public Entity_Controller()
    {
        Attack_Command.Handle(Attack_Command_Handler);
    }

    private void Attack_Command_Handler(Attack_Command command)
    {
        command.Enemy.Hp -= command.Model.Damage;
        new Update_Message();
    }
}
