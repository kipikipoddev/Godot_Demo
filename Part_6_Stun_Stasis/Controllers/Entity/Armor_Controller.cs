using System;
using Commands;
using Core;
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
        if (cmd.Total > 0 & !cmd.Model.Is_Positive)
            cmd.Reduction = Math.Min(cmd.Model.Amount - 1, cmd.Reduction + Get_Reduction(cmd));
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