using Components_Namespace;
using Core;

namespace Commands;

public record Shield_Command(Components Action, Components Target)
    : Command<Shield_Command>()
{
}