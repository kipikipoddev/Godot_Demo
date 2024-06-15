using Components_Namespace;
using Core;

namespace Commands;

public record Attack_Command(Attack_Component Attack, Components Target) 
    : Command
{
}
