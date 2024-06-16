using Commands;
using Core;
using Resources;

namespace Components_Namespace;

public record Attack_Components : Action_Components
{
    public Attack_Components(Attack_Resource resource)
        : base(resource)
    {
        Set(new Amount_Component(resource.Damage));
    }

    public override void Do(Components target)
    {
        new Attack_Command(this, target);
    }
}