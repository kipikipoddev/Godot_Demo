using Core;
using Resources;

namespace Models;

public class Entity_Model
{
    public Ranged_Value<int> Hp { get; set; }
    public Attack_Model Attack_Model { get; }
    public bool Is_Alive => Hp.Value > 0;

    public Entity_Model(Entity_Resource resource)
    {
        Hp = new(resource.Hp, 0, resource.Hp);
        Attack_Model = new Attack_Model(this, resource.Attack);
    }
}
