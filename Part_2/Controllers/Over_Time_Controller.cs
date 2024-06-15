using System.Collections.Generic;
using System.Linq;
using Commands;
using Components_Namespace;
using Messages;

namespace Controllers;

public class Over_Time_Controller
{
    private readonly Dictionary<Timer_Component, Over_Time_Command> timers_to_models;

    public Over_Time_Controller()
    {
        timers_to_models = new();
        Over_Time_Command.Handler = Over_Time_Command_Handler;
        Update_Message.Handle(Update_Message_Handler);
    }

    private void Over_Time_Command_Handler(Over_Time_Command command)
    {
        command.Model.Get<Timer_Component>().Start();
        var timer = Get_Or_Create(command);
        timers_to_models[timer] = command;
        timer.Start();
        Do(timer, command);
    }

    private void Update_Message_Handler(Update_Message message)
    {
        foreach (var timer in timers_to_models.Keys)
            if (timer.Ended)
                Do(timer, timers_to_models[timer]);
    }

    private void Do(Timer_Component timer, Over_Time_Command cmd)
    {
        if (!Can_Do(cmd))
            timers_to_models.Remove(timer);
        else
        {
            var times = cmd.Model.Over_Time().Times;
            if (cmd.Activated++ < times - 1)
                timer.Start();
            else
                timers_to_models.Remove(timer);
            Do(cmd);
        }
    }


    private Timer_Component Get_Or_Create(Over_Time_Command command)
    {
        var existing = timers_to_models.FirstOrDefault(kv => command.Equals(kv.Value));
        if (existing.Key != null)
            return existing.Key;
        else
        {
            var time = command.Model.Over_Time().Time_between;
            return new Timer_Component(time);
        }
    }

    private void Do(Over_Time_Command cmd)
    {
        var is_heal = cmd.Model.Over_Time().Is_heal;
        if (is_heal)
            cmd.Target.Get<Hp_Component>().Hp.Value += cmd.Model.Amount();
        else
            new Damage_Command(cmd.Target, cmd.Model.Amount());
    }

    private static bool Can_Do(Over_Time_Command cmd)
    {
        return cmd.Target.Hp().Not_Min;
    }
}