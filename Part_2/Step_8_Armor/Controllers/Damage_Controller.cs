using System;
using Commands;

namespace Controllers;

public class Damage_Controller
{
    public Damage_Controller()
    {
        Damage_Command.Handler = Damage_Command_Handler;
    }

    private void Damage_Command_Handler(Damage_Command command)
    {
        var amount = Math.Max(1, command.Amount - command.Model.Armor);
        command.Model.Hp.Value -= amount;
    }
}