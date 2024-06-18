using System;
using Commands;
using Components_Namespace;
using Core;

namespace Controllers;

public class Armor_Controller
{
    public Armor_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Hp_Change_Handler);
    }

    private static void Hp_Change_Handler(Hp_Change_Command command)
    {
        var armor_comp = command.Target.Armor();
        if (armor_comp?.Armor > 0)
        {
            var amount_comp = command.Action.Amount();
            amount_comp.Amount = Math.Max(1, amount_comp.Amount - armor_comp.Armor);
        }
    }
}