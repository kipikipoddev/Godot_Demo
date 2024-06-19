using Core;

namespace Commands;

public record Hp_Change_Command(Components Action, Components Target, Hp_Change_Data Data) : Command
{
}
