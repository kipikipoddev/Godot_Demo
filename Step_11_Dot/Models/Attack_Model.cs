using Commands;
using Messages;
using Resources;

namespace Models;

public class Attack_Model
{
    public Entity_Model Owner { get; }
    public Timer_Model Cooldown { get; }
    public int Damage { get; }
    public string Name { get; }

    public Attack_Model(Entity_Model owner, Attack_Resource resource)
    {
        Owner = owner;
        Damage = resource.Damage;
        Name = resource.Name;
        Cooldown = new Timer_Model(resource.Cooldown);
    }

    public virtual void Attack(Entity_Model enemy)
    {
        new Attack_Command(this, enemy);
    }

    public bool Can_Attack(Entity_Model enemy)
    {
        return new Can_Attack_Request(this, enemy).Result;
    }
}
