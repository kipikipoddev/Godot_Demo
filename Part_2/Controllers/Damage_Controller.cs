using System;
using Commands;
using Components_Namespace;

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
        command.Entity.Get<Hp_Component>().Hp.Value -= damage;
    }

    private static int Get_After_Shield(Damage_Command command, int damage)
    {
        var shield = command.Entity.Get_Or_Defualt<Shield_Component>()?.Shield;
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

    private static int Get_After_Armor(Damage_Command command, int damage)
    {
        return Math.Max(1, damage - command.Entity.Armor());
    }
}