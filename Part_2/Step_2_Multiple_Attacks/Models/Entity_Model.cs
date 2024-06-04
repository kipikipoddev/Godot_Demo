using System.Linq;
using Core;
using Resources;

namespace Models;

public class Entity_Model
{
    public Ranged_Value<int> Hp { get; set; }
    public Attack_Model[] Attacks { get; }
    public bool Is_Alive => Hp.Value > 0;

    public Entity_Model(Entity_Resource resource)
    {
        Hp = new(resource.Hp, 0, resource.Hp);
        Attacks = resource.Attacks
            .Select(r => new Attack_Model(this, r))
            .ToArray();
    }
}
