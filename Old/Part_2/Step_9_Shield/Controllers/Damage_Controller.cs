using System;
using Commands;

namespace Controllers;

public class Damage_Controller
{
    public Damage_Controller()
    {
        Damage_Command.Handler = Damage_Command_Handler;
    }

    private void Damage_Command_Handler(Damage_Command command)
    {
        var damage = command.Amount;
        damage = Get_After_Shield(command, damage);
        if (damage > 0)
            damage = Get_After_Armor(command, damage);
        command.Model.Hp.Value -= damage;
    }

    private static int Get_After_Shield(Damage_Command command, int damage)
    {
        var shield = command.Model.Shield.Value;
        if (shield == 0)
            return damage;

        if (shield > damage)
        {
            command.Model.Shield.Value -= damage;
            return 0;
        }
        else
        {
            command.Model.Shield.Value = 0;
            return damage - shield;
        }
    }

    private static int Get_After_Armor(Damage_Command command, int damage)
    {
        return Math.Max(1, damage - command.Model.Armor);
    }
}