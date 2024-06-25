using Resources;

namespace Models;

public class Stasis_Action_Model : Action_Model
{
    public int Time { get; }

    public Stasis_Action_Model(Stasis_Resource resource)
        : base(resource, false, true)
    {
        Time = resource.Time;
    }
}