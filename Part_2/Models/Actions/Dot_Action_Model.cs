using Commands;
using Core;
using Interfaces;
using Resources;

namespace Models;

public class Dot_Action_Model : Attack_Action_Model, IOvertime_Model
{
    public int Time_between { get; }
    public int Times { get; }

    public Dot_Action_Model(Dot_Resource resource)
        : base(resource)
    {
    }

    public override Command Do(IHp_Model target)
    {
        var cmd = base.Do(target);
        return new Over_Time_Command(this, cmd, target);
    }
}