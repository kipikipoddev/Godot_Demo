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

    }
}