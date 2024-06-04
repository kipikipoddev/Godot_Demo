using Commands;

namespace Models;

public class Attack_Model
{
    public int Damage { get; }

    public Attack_Model(Entity_Resource resource)
    {
        Damage = resource.Damage;
    }

    public void Attack(Entity_Model target)
    {
        new Attack_Command(this, target);
    }
}
