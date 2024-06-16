using Commands;
using Core;
using Interfaces;
using Resources;

namespace Models;

public class Hot_Action_Model : Heal_Action_Model, IOvertime_Model
{
    public int Time_between { get; }
    public int Times { get; }

    public Hot_Action_Model(Hot_Resource resource)
        : base(resource)
    {
    }

    public override Command Do(IHp_Model target)
    {
        var cmd = base.Do(target);
        return new Over_Time_Command(this, cmd, target);
    }
}