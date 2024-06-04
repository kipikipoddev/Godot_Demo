namespace Models;

public class Entity_Model
{
    public int Hp { get; set; }

    public Entity_Model(Entity_Resource resource)
    {
        Hp = resource.Hp;
    }
}
