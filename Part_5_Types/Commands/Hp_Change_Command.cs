using Core;
using Interfaces;

namespace Commands;

public record Hp_Change_Command(IAmount_Model Model, IEntity_Model Target) : Command
{
    public int Reduction { get; set; }
    public int Total => Model.Amount - Reduction;
}