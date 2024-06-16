using Commands;
using Core;

namespace Components_Namespace;

public record Shield_Action_Components : Action_Components
{
    public Shield_Action_Components(string name, int cooldown, int shield)
        : base(name, cooldown)
    {
        Set(new Amount_Component(shield));
    }
    
    public override void Do(Components target)
    {
        new Shield_Action_Command(this, target);
    }
}