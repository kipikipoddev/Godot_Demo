using System.Linq;
using Interfaces;
using Resources;

namespace Models;

public class Effect_Model : IEffect_Model
{
    public ITimer_Model Time { get; }
    public Type_Resource Type { get; }
    public string Name { get; }
    public double Time_Left => Time.Current;
    public IEntity_Model Target { get; }

    public Effect_Model(IAction_Model action, IEntity_Model target, int time)
    {
        Type = action.Type;
        Name = action.Name;
        Time = new Timer_Model(time);
        Target = target;
        if (!target.Effects.Any(e => e.Name == Name))
            target.Effects.Add(this);
    }
}