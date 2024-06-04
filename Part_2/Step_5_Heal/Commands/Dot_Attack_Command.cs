using Core;
using Models;

namespace Commands;

public record Dot_Attack_Command(Dot_Attack_Model Model, Entity_Model Target)
    : Message<Dot_Attack_Command>()
{
    public int Activated { get; set; }
}
