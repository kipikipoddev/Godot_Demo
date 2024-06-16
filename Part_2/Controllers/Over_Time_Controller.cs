using System.Collections.Generic;
using System.Linq;
using Commands;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Over_Time_Controller
{
    private readonly List<Components> effects;

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

    private void Do(Components components)
    {
        if (!Can_Do(components))
            effects.Remove(components);
        else
        {
            var effect = components.Effect();
            if (++effect.Happend < effect.Times)
                components.Timer().Start();
            else
                effects.Remove(components);
            effect.Action.Invoke();
        }
    }

    private void Create_Or_Reset(Over_Time_Command command)
    {
        var existing = effects.FirstOrDefault(e => Equals(command, e));
        if (existing != null)
        {
            existing.Timer().Start();
            existing.Effect().Happend = 0;
        }
        else
        {
            var components = Get_Components(command);
            effects.Add(components);
            command.Target.Add(components);
        }
    }

    private static Components Get_Components(Over_Time_Command command)
    {
        var over_time = command.Action.Over_Time();
        return new Components()
              .Set(command.Action.Get<Name_Component>())
              .Set(new Effect_Component(command.Command, over_time.Times - 1))
              .Set(new Timer_Component(over_time.Time_between));
    }


    private static bool Equals(Over_Time_Command command, Components components)
    {
        return components.Name().Equals(command.Action.Name());
    }

    private static bool Can_Do(Components comp)
    {
        return comp.Parent.Hp().Is_Alive;
    }
}