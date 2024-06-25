using Commands;
using Models;
using Core;
using Messages;
using System.Collections.Generic;
using Interfaces;

namespace Controllers;

public class Effects_Controller
{
    private readonly List<IEffect_Model> effects;

    public Effects_Controller()
    {
        effects = new();
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
        Mediator.Add_Listener<Update_Message>(Update_Handler);
    }

    private void Update_Handler(Update_Message message)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            var target_effects = effects[i].Target.Effects;
            if (effects[i].Ended)
                Remove(target_effects, effects[i]);
            else if (effects[i] is Stasis_Model)
                for (int j = 0; j < target_effects.Count; j++)
                    if (effects[i] != target_effects[j])
                        Remove(target_effects, target_effects[j]);
        }
    }

    private void Remove(List<IEffect_Model> target_effects, IEffect_Model effect)
    {
        effects.Remove(effect);
        target_effects.Remove(effect);
        if (effect is Stasis_Model)
            Set_Paused(effect.Target, false);
    }

    private void Do_Action_Handler(Do_Action_Command cmd)
    {

        if (cmd.Action is Stun_Action_Model stun)
            effects.Add(new Stun_Model(stun, cmd.Target));
        else if (cmd.Action is Stasis_Action_Model stasis)
        {
            Set_Paused(cmd.Target, true);
            effects.Add(new Stasis_Model(stasis, cmd.Target));
        }
        else if (cmd.Action is IOver_Timer_Model over_time_model)
            effects.Add(Get_Over_Time(cmd, over_time_model));
    }

    private static Effect_Model Get_Over_Time(Do_Action_Command cmd, IOver_Timer_Model over_time_model)
    {
        var total_time = over_time_model.Time_Between * (over_time_model.Times - 1);
        return new Effect_Model(cmd.Action, cmd.Target, total_time);
    }

    private void Set_Paused(IEntity_Model target, bool is_paused)
    {
        foreach (var target_action in target.Actions)
            target_action.Cooldown.Is_Paused = is_paused;
    }
}