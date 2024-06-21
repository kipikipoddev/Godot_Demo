using System;
using Commands;
using Core;

namespace Controllers;

public class Hp_Controller
{
    public Hp_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Hp_Change_Handler);
    }

    private static void Hp_Change_Handler(Hp_Change_Command cmd)
    {
        var amount = cmd.Model.Amount;
        cmd.Target.Hp.Value += amount.Value * (cmd.Model.Is_Positive ? 1 : -1);
        amount.Value = amount.Max;
    }
}