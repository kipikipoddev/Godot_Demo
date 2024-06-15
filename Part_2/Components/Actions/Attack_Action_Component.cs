using Commands;
using Core;

namespace Components_Namespace;

public record Attack_Action_Components : Action_Components
{
    public Attack_Action_Components(string name, int cooldown, int damage)
        : base(name, cooldown)
    {
        Set(new Amount_Component(damage));
    }

    public override void Do(Components target)
    {
        new Attack_Command(this, target);
    }
}