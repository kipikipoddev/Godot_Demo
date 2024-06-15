using System.Collections.Generic;
using System.Linq;
using Commands;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Over_Time_Controller
{
    private readonly Dictionary<Ranged_Value<double>, Over_Time_Command> timers_to_models;

    public Over_Time_Controller()
    {
        timers_to_models = new();
        Mediator.Add_Listener<Over_Time_Command>(Over_Time_Command_Handler);
        Mediator.Add_Listener<Update_Message>(Update_Message_Handler);
    }

    private void Over_Time_Command_Handler(Over_Time_Command command)
    {
        var timer = Get_Or_Create(command);
        new Start_Timer_Command(timer);
        timers_to_models[timer] = command;
        Do(timer, command);
    }

    private void Update_Message_Handler(Update_Message message)
    {
        foreach (var timer in timers_to_models.Keys)
            if (timer.Is_Min)
                Do(timer, timers_to_models[timer]);
    }

    private void Do(Ranged_Value<double> timer, Over_Time_Command cmd)
    {
        if (!Can_Do(cmd))
            timers_to_models.Remove(timer);
        else
        {
            var times = cmd.Model.Get_Over_Time().Times;
            if (cmd.Activated++ < times - 1)
                new Start_Timer_Command(timer);
            else
                timers_to_models.Remove(timer);
            Do(cmd);
        }
    }

    private Ranged_Value<double> Get_Or_Create(Over_Time_Command command)
    {
        var existing = timers_to_models.FirstOrDefault(kv => command.Equals(kv.Value));
        if (existing.Key != null)
            return existing.Key;
        else
        {
            var time = command.Model.Get_Over_Time().Time_between;
            command.Model.Set_Timer(time);
            return command.Model.Get_Timer();
        }
    }

    private void Do(Over_Time_Command cmd)
    {
        var is_heal = cmd.Model.Get_Over_Time().Is_heal;
        if (is_heal)
            cmd.Target.Get_Hp().Value += cmd.Model.Get_Amount();
        else
            new Damage_Command(cmd.Target, cmd.Model.Get_Amount());
    }

    private static bool Can_Do(Over_Time_Command cmd)
    {
        return cmd.Target.Get_Hp().Not_Min;
    }
}