using System;
using Commands;
using Core;
using Interfaces;
using Resources;

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
            cmd.Model.Amount.Value = Math.Max(1, value - Get_Reduction(cmd));
    }

    private static int Get_Reduction(Hp_Change_Command cmd)
    {
        var reduction = 0;
        foreach (var armor in cmd.Target.Armor)
            if (Is_Fit(cmd.Model.Type, armor.Type.Name))
                reduction += armor.Amount;
        return reduction;
    }

    private static bool Is_Fit(Type_Resource type, string name)
    {
        if (type == null)
            return false;
        if (type.Name == name)
            return true;
        return Is_Fit(type.Parent, name);
    }
}