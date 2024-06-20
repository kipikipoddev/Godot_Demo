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

    private static void Hp_Change_Handler(Hp_Change_Command cmd)
    {
        var armor_comp = cmd.Target.Armor();
        if (Should_Reduce_Armor(cmd, armor_comp))
            cmd.Amount = Math.Min(-1, cmd.Amount + armor_comp.Armor);
    }

    private static bool Should_Reduce_Armor(Hp_Change_Command cmd, Armor_Component comp)
    {
        return comp?.Armor > 0 & cmd.Amount < 0;
    }
}