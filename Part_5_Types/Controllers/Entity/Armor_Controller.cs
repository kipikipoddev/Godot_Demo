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
        var armor_comps = cmd.Target.Get_Armors();
        if (cmd.Amount < 0)
            foreach (var armor_comp in armor_comps)
                cmd.Amount = Get_Reduced(armor_comp, cmd.Amount);
    }

    private static int Get_Reduced(Armor_Component armor_comp, int amount)
    {
        return amount;
    }

}