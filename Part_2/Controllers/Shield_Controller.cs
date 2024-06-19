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
        if (shield == null || command.Data.Is_Positive)
            return;
        shield.Value -= command.Data.Amount;
        command.Data.Amount = shield.Value >= 0 ? 0 : -shield.Value;
        if (shield.Value <= 0)
            command.Target.Remove<Shield_Component>();
    }
}