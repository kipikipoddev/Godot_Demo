using Core;
using Interfaces;
using Models;

namespace Commands;

public record Heal_Command(Heal_Model Model, IHp_Model Target)
    : Command<Heal_Command>()
{
}