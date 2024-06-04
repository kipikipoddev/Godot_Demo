using Commands;
using Interfaces;
using Resources;

namespace Models;

public class Dot_Model : Attack_Model, IOver_Time_Model
{
    public int Time_Between { get; }
    public int Times { get; }

    public Dot_Model(IHp_Model owner, Dot_Resource resource)
    : base(owner, resource)
    {
        Time_Between = resource.Time_Between;
        Times = resource.Times;
    }

    public override void Do(IHp_Model target)
    {
        new Over_Time_Command(this, target);
    }
}