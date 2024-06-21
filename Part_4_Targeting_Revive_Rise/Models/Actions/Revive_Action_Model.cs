using Resources;

namespace Models;

public class Revive_Action_Model : Action_Model
{
    public int To_Hp { get; }

    public Revive_Action_Model(Revive_Resource resource)
        : base(resource, true, false)
    {
        To_Hp = resource.To_Hp;
    }
}