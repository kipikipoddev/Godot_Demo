using Core;

namespace Commands;

public record Hp_Change_Command(Components Entity, int Amount, bool Is_Positive) : Command
{
}
