using Core;

namespace Commands;

public record Hp_Change_Command(Components Action, Components Target, int Amount, bool Is_Positive) : Command
{
}
