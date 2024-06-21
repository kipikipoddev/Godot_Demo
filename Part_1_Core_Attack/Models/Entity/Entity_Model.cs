using System;
using Interfaces;
using Resources;

namespace Models;

public class Entity_Model : Name_Model, IEntity_Model
{
    public IValue_Model Hp { get; }
    public IAction_Model Action { get; }

    public Entity_Model(Entity_Resource resource, Func<Action_Resource, IAction_Model> action_mapper)
        : base(resource)
    {
        Hp = new Value_Model(resource.Hp);
        Action = action_mapper(resource.Action);
        Action.Owner = this;
    }
}