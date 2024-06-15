using Commands;
using Core;

namespace Components_Namespace;

public record Heal_Action_Components : Action_Components
{
    public Heal_Action_Components(string name, int cooldown, int heal)
        : base(name, cooldown)
    {
        Set(new Amount_Component(heal));
    }

    public override void Do(Components target)
    {
        new Heal_Command(this, target);
    }
}