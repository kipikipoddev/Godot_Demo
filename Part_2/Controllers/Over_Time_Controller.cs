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
        var effect = Get_Or_Create(command);
        effect.Timer().Start();
        Do(effect);
    }

    private void Update_Message_Handler(Update_Message message)
    {
        foreach (var effect in effects)
            if (effect.Timer().Ended)
                Do(effect);
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
            effect.Action.Do(effect.Parent);
        }
    }

    private Effect_Component Get_Or_Create(Over_Time_Command command)
    {
        var existing = effects.FirstOrDefault(e => Equals(command, e));
        if (existing != null)
            return existing;
        else
        {
            var effect = new Effect_Component(command.Action);
            command.Target.Add(effect);
            return effect;
        }
    }

    private static bool Equals(Over_Time_Command command, Effect_Component e)
    {
        return e.Action.Name().Equals(command.Action.Name());
    }

    private static bool Can_Do(Effect_Component comp)
    {
        return comp.Parent.Hp().Not_Min;
    }
}