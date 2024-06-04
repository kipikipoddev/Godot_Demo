using Resources;

namespace Models;

public abstract class Action_Model
{
    public Entity_Model Owner { get; }
    public Timer_Model Cooldown { get; }
    public string Name { get; }

    public Action_Model(Entity_Model owner, Action_Resource resource)
    {
        Owner = owner;
        Name = resource.Name;
        Cooldown = new Timer_Model(resource.Cooldown);
    }

    public abstract void Do(Entity_Model target);

    public abstract bool Can_Do(Entity_Model target);
}