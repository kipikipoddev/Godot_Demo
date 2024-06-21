using Interfaces;
using Resources;

namespace Models;

public class Hot_Action_Model : Heal_Action_Model, IOver_Timer_Model
{
    public int Times { get; }
    public int Time_Between { get; }
    public Hot_Action_Model(Hot_Resource resource)
        : base(resource)
    {
        Times = resource.Times;
        Time_Between = resource.Time_Between;
    }
}