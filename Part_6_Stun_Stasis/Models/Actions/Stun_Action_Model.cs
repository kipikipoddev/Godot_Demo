using Resources;

namespace Models;

public class Stun_Action_Model : Action_Model
{
    public int Time { get; }

    public Stun_Action_Model(Stun_Resource resource)
        : base(resource, false, true)
    {
        Time = resource.Time;
    }
}