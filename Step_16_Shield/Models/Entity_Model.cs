using System.Collections.Generic;
using Core;
using Interfaces;
using Resources;

namespace Models;

public class Entity_Model : IEntity_Model
{
    public Ranged_Value<int> Hp { get; set; }
    public List<IAction_Model> Actions { get; }
    public int Armor { get; }
    public Ranged_Value<int> Shield { get; set; }
    public Entity_Model(Entity_Resource resource)
    {
        Hp = new(resource.Hp, 0, resource.Hp);
        Armor = resource.Armor;
        Actions = new();
        Shield = new(0, 0, 0);
    }
}
