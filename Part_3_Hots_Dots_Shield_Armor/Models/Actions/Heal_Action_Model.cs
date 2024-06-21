using Resources;

namespace Models;

public class Heal_Action_Model : Hp_Change_Action_Model
{
    public Heal_Action_Model(Heal_Resource resource)
        : base(resource, resource.Heal, true)
    {
    }
}