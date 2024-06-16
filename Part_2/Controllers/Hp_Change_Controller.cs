using System;
using Commands;
using Components_Namespace;
using Core;

namespace Controllers;

public class Hp_Change_Controller
{
    public Hp_Change_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Damage_Command_Handler);
    }

    private void Damage_Command_Handler(Hp_Change_Command command)
    {
        var amount = command.Amount;
        if (command.Is_Positive)
            command.Entity.Hp().Value += amount;
        else
        {
            amount = Get_After_Shield(command, amount);
            if (amount > 0)
                amount = Get_After_Armor(command, amount);
            command.Entity.Hp().Value -= amount;
        }
    }

    private static int Get_After_Shield(Hp_Change_Command command, int damage)
    {
        var shield = command.Entity.Shield();
        if (shield == null)
            return damage;

        if (shield.Value > damage)
        {
            shield.Value -= damage;
            return 0;
        }
        else
        {
            command.Entity.Remove<Shield_Component>();
            return damage - shield.Value;
        }
    }

    private static int Get_After_Armor(Hp_Change_Command command, int damage)
    {
        return Math.Max(1, damage - command.Entity.Armor());
    }
}