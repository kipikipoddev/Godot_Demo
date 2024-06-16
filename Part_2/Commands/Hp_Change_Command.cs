using Components_Namespace;
using Core;

namespace Commands;

public record Hp_Change_Command(Components Target, int Amount, bool Is_Positive) : Command
{
}
