using System.Collections.Generic;
using System.Linq;
using Commands;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Over_Time_Controller
{
    private readonly List<Effect_Component> effects;

    public Over_Time_Controller()
    {
        effects = new();
        Mediator.Add_Listener<Over_Time_Command>(Over_Time_Command_Handler);
        Mediator.Add_Listener<Update_Message>(Update_Message_Handler);
    }

    private void Over_Time_Command_Handler(Over_Time_Command command)
    {
        Create_Or_Reset(command);
    }

    private void Update_Message_Handler(Update_Message message)
    {
        for (int i = 0; i < effects.Count; i++)
            if (effects[i].Timer().Ended)
                Do(effects[i]);
    }

    private void Do(Effect_Component effect)
    {
        if (!Can_Do(effect))
            effects.Remove(effect);
        else
        {
            effect.Left--;
            if (effect.Left > 0)
                effect.Timer().Start();
            else
                effects.Remove(effect);
            effect.Command.Invoke();
        }
    }

    private void Create_Or_Reset(Over_Time_Command command)
    {
        var existing = effects.FirstOrDefault(e => Equals(command, e));
        if (existing != null)
            existing.Timer().Start();
        else
        {
            var effect = new Effect_Component(command.Action, command.Command);
            effects.Add(effect);
            command.Target.Add(effect);
        }
    }

    private static bool Equals(Over_Time_Command command, Effect_Component e)
    {
        return e.Name().Equals(command.Action.Name());
    }

    private static bool Can_Do(Effect_Component comp)
    {
        return comp.Parent.Hp().Not_Min;
    }
}