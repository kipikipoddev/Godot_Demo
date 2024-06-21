using System;
using Commands;
using Core;

namespace Controllers;

public class Armor_Controller
{
    public Armor_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Hp_Change_Handler);
    }

    private static void Hp_Change_Handler(Hp_Change_Command cmd)
    {
        var value = cmd.Model.Amount.Value;
        if (value > 0 & !cmd.Model.Is_Positive)
            cmd.Model.Amount.Value = Math.Max(1, value - cmd.Target.Armor);
    }
}