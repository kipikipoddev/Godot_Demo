using Commands;
using Core;

namespace Components_Namespace;

public record Attack_Component : Action_Component
{
    public Attack_Component(string name, int damage)
    {
        Set(new Name_Component(name));
        Set(new Amount_Component(damage));
    }

    public override void Do(Components target)
    {
        new Attack_Command(this, target);
    }
}