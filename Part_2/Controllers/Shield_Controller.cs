using Commands;
using Components_Namespace;
using Core;

namespace Controllers;

public class Shield_Controller
{
    public Shield_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Hp_Change_Handler);
    }

    private static void Hp_Change_Handler(Hp_Change_Command command)
    {
        var shield = command.Target.Shield();
        if (shield == null)
            return;
        var amount_comp = command.Action.Amount();
        shield.Value -= amount_comp.Amount;
        if (shield.Value <= 0)
        {
            amount_comp.Amount = -shield.Value;
            command.Target.Remove<Shield_Component>();
        }
        else
            amount_comp.Amount = 0;

    }
}