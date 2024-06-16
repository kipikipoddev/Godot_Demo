using System.ComponentModel;
using Commands;
using Core;

namespace Components_Namespace;

public record Hp_Change_Action_Component() : Action_Component
{
    public override void Do(Components target)
    {
        new Hp_Change_Action_Command(Parent, target);
    }
}