using Commands;
using Core;
using Resources;

namespace Components_Namespace;

public record Heal_Action_Components : Action_Components
{
    public Heal_Action_Components(Heal_Resource resource)
        : base(resource)
    {
        Set(new Amount_Component(resource.Heal));
    }

    public override void Do(Components target)
    {
        new Heal_Command(this, target);
    }
}