using Commands;

namespace Models;

public class Entity_Model
{
    public int Hp { get; set; }
    public int Damage { get; set; }

    public Entity_Model(Entity_Resource resource)
    {
        Hp = resource.Hp;
        Damage = resource.Damage;
    }

    public void Attack(Entity_Model enemy)
    {
        new Attack_Command(this, enemy);
    }
}
