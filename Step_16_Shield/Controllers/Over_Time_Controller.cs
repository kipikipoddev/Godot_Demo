using System.Collections.Generic;
using System.Linq;
using Commands;
using Interfaces;
using Messages;
using Models;

namespace Controllers;

public class Over_Time_Controller
{
    private readonly Dictionary<ITimer_Model, Over_Time_Command> timers_to_models;

    public Over_Time_Controller()
    {
        timers_to_models = new();
        Over_Time_Command.Handler = Over_Time_Command_Handler;
        Update_Message.Handle(Update_Message_Handler);
    }

    private void Over_Time_Command_Handler(Over_Time_Command command)
    {
        var timer = Get_Or_Create(command);
        timers_to_models[timer] = command;
        command.Model.Cooldown.Start();
        Dot_Attack(timer, command);
    }

    private void Update_Message_Handler(Update_Message message)
    {
        foreach (var timer in timers_to_models.Keys)
            if (timer.Ended)
                Dot_Attack(timer, timers_to_models[timer]);
    }

    private void Dot_Attack(ITimer_Model timer, Over_Time_Command cmd)
    {
        if (!Can_Do(cmd))
            timers_to_models.Remove(timer);
        else
            Do(timer, cmd);
    }

    private void Do(ITimer_Model timer, Over_Time_Command cmd)
    {
        if (cmd.Activated++ < cmd.Model.Times - 1)
            timer.Start();
        else
            timers_to_models.Remove(timer);
        Do(cmd);
    }


    private ITimer_Model Get_Or_Create(Over_Time_Command command)
    {
        var existing = timers_to_models.FirstOrDefault(kv => command.Equals(kv.Value));
        if (existing.Key != null)
            return existing.Key;
        else
            return new Timer_Model(command.Model.Time_Between, false);
    }

    private void Do(Over_Time_Command cmd)
    {
        if (cmd.Model is Dot_Model)
            new Damage_Command(cmd.Target, (cmd.Model as Dot_Model).Damage);
        else
            cmd.Target.Hp.Value += (cmd.Model as Hot_Model).Heal;
    }

    private static bool Can_Do(Over_Time_Command cmd)
    {
        return cmd.Target.Is_Alive;
    }
}