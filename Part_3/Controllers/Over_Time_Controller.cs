using System.Collections.Generic;
using System.Linq;
using Commands;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Over_Time_Controller
{
    private readonly List<Over_Time_Command> commands;

    public Over_Time_Controller()
    {
        commands = new();
        Mediator.Add_Listener<Over_Time_Command>(Over_Time_Handler);
        Mediator.Add_Listener<Update_Message>(Update_Handler);
    }

    private void Update_Handler(Update_Message msg)
    {
        for (int i = 0; i < commands.Count; i++)
            if (commands[i].Timer.Ended)
                Run(commands[i]);

    }
    private void Run(Over_Time_Command cmd)
    {
        if (!Can_Run(cmd))
            commands.Remove(cmd);
        else
        {
            new Hp_Change_Command(cmd.Target, cmd.Amount);
            if (++cmd.Runs == cmd.Times - 1)
                commands.Remove(cmd);
            else
                cmd.Timer.Start();
        }
    }

    private void Over_Time_Handler(Over_Time_Command cmd)
    {
        var existing = commands.FirstOrDefault(c => c.Name == cmd.Name);
        if (existing != null)
        {
            existing.Timer.Start();
            existing.Runs = 0;
        }
        else
        {
            cmd.Timer = new Timer_Component(cmd.Time_Between);
            commands.Add(cmd);
        }
    }

    private bool Can_Run(Over_Time_Command cmd)
    {
        return cmd.Target.Hp().Is_Alive;
    }
}