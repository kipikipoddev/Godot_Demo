using Interfaces;
using Resources;

namespace Models;

public class Dot_Action_Model : Attack_Action_Model, IOver_Timer_Model
{
    public int Times { get; }
    public int Time_Between { get; }
    public Dot_Action_Model(Dot_Resource resource)
        : base(resource)
    {
        Times = resource.Times;
        Time_Between = resource.Time_Between;
    }
}