using System;
using Commands;
using Components_Namespace;
using Core;

namespace Controllers;

public class Hp_Controller
{
    public Hp_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Hp_Change_Handler);
    }

    private static void Hp_Change_Handler(Hp_Change_Command command)
    {
        var hp_comp = command.Target.Hp();
        hp_comp.Value += Get_Amount(command);
        hp_comp.Value = Get_Bounded(hp_comp);
    }

    private static int Get_Amount(Hp_Change_Command command)
    {
        return command.Action.Amount().Amount * (command.Is_Positive ? 1 : -1);
    }

    private static int Get_Bounded(Hp_Component hp_comp)
    {
        return Math.Min(hp_comp.Max, Math.Max(0, hp_comp.Value));
    }
}