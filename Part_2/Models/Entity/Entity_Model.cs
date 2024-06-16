using Core;
using Interfaces;
using Resources;

namespace Models;

public class Entity_Model : IName_Model, IHp_Model, IActions_Model
{
    public string Name { get; }
    public Ranged_Value<int> Hp { get; }
    public IActions_Model[] Actions { get; }

    public Entity_Model(Entity_Resource resource)
    {
        Name = resource.Name;
        Hp = new(resource.Hp, 0, resource.Hp);
    }
}