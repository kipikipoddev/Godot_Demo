using Core;
using Interfaces;

namespace Commands;

public record Hp_Change_Command(IAmount_Model Model, IEntity_Model Target) : Command
{
}