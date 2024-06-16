using Components_Namespace;
using Core;

namespace Commands;

public record Shield_Action_Command(Shield_Action_Components Action, Components Target) : Command
{
}