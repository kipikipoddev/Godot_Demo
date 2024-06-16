using Commands;
using Core;
using Resources;

namespace Components_Namespace;

public record Shield_Action_Components : Action_Components
{
    public Shield_Action_Components(Shield_Resource resource)
        : base(resource)
    {
        Set(new Amount_Component(resource.Amount));
    }

    public override void Do(Components target)
    {
        new Shield_Action_Command(this, target);
    }
}