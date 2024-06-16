using Commands;
using Core;

namespace Components_Namespace;

public record Shield_Action_Component() : Action_Component
{
    public override void Do(Components target)
    {
        new Shield_Action_Command(Parent, target.Parent);
    }
}