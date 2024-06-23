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
        if (cmd.Total > 0 & !cmd.Model.Is_Positive)
            cmd.Reduction = Math.Min(cmd.Model.Amount - 1, cmd.Reduction + cmd.Target.Armor);
    }
}