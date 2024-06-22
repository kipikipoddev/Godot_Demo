using Commands;
using Core;

namespace Controllers;

public class Shield_Controller
{
    public Shield_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Hp_Change_Handler);
    }

    private static void Hp_Change_Handler(Hp_Change_Command cmd)
    {
        var shield = cmd.Target.Shield;
        if (cmd.Model.Is_Positive | shield.Value == 0)
            return;

        var orignal_amount = cmd.Model.Amount.Value;
        cmd.Model.Amount.Value -= shield.Value;
        shield.Value -= orignal_amount;
    }
}