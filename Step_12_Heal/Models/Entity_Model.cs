using System.Linq;
using Core;
using Resources;

namespace Models;

public class Entity_Model
{
    public Ranged_Value<int> Hp { get; set; }
    public Action_Model[] Actions { get; }
    public bool Is_Alive => Hp.Value > 0;

    public Entity_Model(Entity_Resource resource)
    {
        Hp = new(resource.Hp, 0, resource.Hp);
        Actions = resource.Actions.Select(Get_Model).ToArray();
    }

    private Action_Model Get_Model(Action_Resource resource)
    {
        if (resource is Dot_Resource)
            return new Dot_Attack_Model(this, resource as Dot_Resource);
        if (resource is Attack_Resource)
            return new Attack_Model(this, resource as Attack_Resource);
        if (resource is Heal_Resource)
            return new Heal_Model(this, resource as Heal_Resource);
        return null;
    }
}