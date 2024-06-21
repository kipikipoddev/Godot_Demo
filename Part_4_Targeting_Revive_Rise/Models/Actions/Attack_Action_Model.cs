using Resources;

namespace Models;

public class Attack_Action_Model : Hp_Change_Action_Model
{
    public Attack_Action_Model(Attack_Resource resource)
        : base(resource, resource.Damage, false, true)
    {
    }
}