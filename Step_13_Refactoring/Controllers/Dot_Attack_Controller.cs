using System.Collections.Generic;
using System.Linq;
using Commands;
using Interfaces;
using Messages;
using Models;

namespace Controllers;

public class Dot_Attack_Controller
{
    private readonly Dictionary<ITimer_Model, Dot_Attack_Command> timers_to_models;

    public Dot_Attack_Controller()
    {
        timers_to_models = new();
        Dot_Attack_Command.Handler = Dot_Attack_Command_Handler;
        Update_Message.Handle(Update_Message_Handler);
    }

    private void Dot_Attack_Command_Handler(Dot_Attack_Command command)
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

    private void Dot_Attack(ITimer_Model timer, Dot_Attack_Command cmd)
    {
        if (!Can_Attack(cmd))
            timers_to_models.Remove(timer);
        else
        {
            if (cmd.Activated++ < cmd.Model.Times - 1)
                timer.Start();
            else
                timers_to_models.Remove(timer);
            cmd.Target.Hp.Value -= cmd.Model.Damage;
            new Update_Message();
        }
    }

    private static bool Can_Attack(Dot_Attack_Command cmd)
    {
        return cmd.Target.Is_Alive;
    }

    private ITimer_Model Get_Or_Create(Dot_Attack_Command command)
    {
        var existing = timers_to_models.FirstOrDefault(kv => Equals(kv.Value, command));
        if (existing.Key != null)
            return existing.Key;
        else
            return new Timer_Model(command.Model.Time_Between, false);
    }

    private static bool Equals(Dot_Attack_Command cmd1, Dot_Attack_Command cmd2)
    {
        return cmd1.Target == cmd2.Target & cmd1.Model.Name == cmd2.Model.Name;
    }
}