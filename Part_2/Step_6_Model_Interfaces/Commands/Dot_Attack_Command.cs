using Core;
using Interfaces;
using Models;

namespace Commands;

public record Dot_Attack_Command(Dot_Attack_Model Model, IHp_Model Target)
    : Command<Dot_Attack_Command>()
{
    public int Activated { get; set; }
}
