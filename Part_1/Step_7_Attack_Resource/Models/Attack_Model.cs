using Commands;
using Messages;
using Resources;

namespace Models;

public class Attack_Model
{
    public Entity_Model Owner { get; }
    public int Damage { get; }

    public Attack_Model(Entity_Model owner, Attack_Resource resource)
    {
        Owner = owner;
        Damage = resource.Damage;
    }

    public void Attack(Entity_Model target)
    {
        new Attack_Command(this, target);
    }

    public bool Can_Attack(Entity_Model target)
    {
        return new Can_Attack_Request(this, target).Result;
    }
}