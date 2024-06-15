using Commands;
using Core;
using Messages;

namespace Components_Namespace;

public record Attack_Component : Components
{
    public Attack_Component(string name, int damage)
    {
        Set(new Name_Component(name));
        Set(new Amount_Component(damage));
    }

    public void Attack(Components target)
    {
        new Attack_Command(this, target);
    }

    public bool Can_Attack(Components target)
    {
        return new Can_Attack_Request(this, target).Result;
    }
}

public static class Components_Attack_Extension
{
    public static Attack_Component Attack(this Components components)
    {
        return components.Get<Attack_Component>();
    }
}