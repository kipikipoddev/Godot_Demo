using Core;

namespace Commands;

public record Attack_Command(Components Attack, Components Target) : Command
{
}
