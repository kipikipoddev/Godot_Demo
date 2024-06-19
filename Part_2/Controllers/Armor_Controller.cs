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
        if (Should_Reduce_Armor(command, armor_comp))
            command.Data.Amount = Math.Max(1, command.Data.Amount - armor_comp.Armor);
    }

    private static bool Should_Reduce_Armor(Hp_Change_Command command, Armor_Component armor_comp)
    {
        return armor_comp?.Armor > 0 & 
            !command.Data.Is_Positive & 
            command.Data.Amount > 0;
    }

}