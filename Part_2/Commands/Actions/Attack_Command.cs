using Components_Namespace;
using Core;

namespace Commands;

public record Attack_Command(Attack_Action_Components Attack, Components Target) : Command
{
}