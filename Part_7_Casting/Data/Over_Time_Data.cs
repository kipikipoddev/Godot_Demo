using Commands;
using Interfaces;
using Models;

namespace Data;

public class Over_Time_Data
{
    public Over_Time_Command Command { get; }
    public int Runs_Left { get; set; }
    public ITimer_Model Timer { get; set; }

    public Over_Time_Data(Over_Time_Command command)
    {
        Command = command;
        Timer = new Timer_Model(command.Model.Time_Between);
        Runs_Left = command.Model.Times - 1;
    }
}