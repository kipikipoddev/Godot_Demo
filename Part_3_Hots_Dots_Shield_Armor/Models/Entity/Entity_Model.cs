using Interfaces;
using Resources;

namespace Models;

public class Entity_Model : Name_Model, IEntity_Model
{
    public IValue_Model Hp { get; }
    public int Armor { get; }
    public IValue_Model Shield { get; }
    public IAction_Model[] Actions { get; }

    public Entity_Model(Entity_Resource resource, IAction_Model[] actions)
        : base(resource)
    {
        Hp = new Value_Model(resource.Hp);
        Armor = resource.Armor;
        Shield = new Value_Model(0);
        Actions = actions;
        foreach (var action in Actions)
            action.Owner = this;
    }
}