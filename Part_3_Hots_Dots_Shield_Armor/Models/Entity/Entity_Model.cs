using System;
using System.Linq;
using Interfaces;
using Resources;

namespace Models;

public class Entity_Model : Name_Model, IEntity_Model
{
    public IValue_Model Hp { get; }
    public int Armor { get; }
    public IValue_Model Shield { get; }
    public IAction_Model[] Actions { get; }

    public Entity_Model(Entity_Resource resource, Func<Action_Resource, IAction_Model> action_mapper)
        : base(resource)
    {
        Hp = new Value_Model(resource.Hp);
        Armor = resource.Armor;
        Shield = new Value_Model(0);
        Actions = resource.Actions.Select(action_mapper).ToArray();
        foreach (var action in Actions)
            action.Owner = this;
    }
}