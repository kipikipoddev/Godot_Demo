using Commands;
using Interfaces;

namespace Data;

public class Casting_Data
{
    public IAction_Model Action { get; }
    public IEntity_Model Target { get; }
    public IValue_Model<double> Casting { get; }

    public Casting_Data(Start_Action_Command cmd, IValue_Model<double> casting)
    {
        Action = cmd.Action;
        Target = cmd.Target;
        Casting = casting;
    }
}