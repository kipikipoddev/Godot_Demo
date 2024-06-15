using Components_Namespace;
using Core;

namespace Commands;

public record Shield_Command(Shield_Action_Components Action, Components Target) : Command
{
}