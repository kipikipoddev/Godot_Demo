using Resources;

namespace Models;

public class Rise_Action_Model : Action_Model
{
    public int To_Hp { get; }

    public Rise_Action_Model(Rise_Resource resource)
        : base(resource, false, false)
    {
        To_Hp = resource.To_Hp;
    }
}