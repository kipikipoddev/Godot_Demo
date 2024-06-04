using Core;
using Interfaces;
using Models;

namespace Commands;

public record Attack_Command(Attack_Model Model, IHp_Model Target)
    : Command<Attack_Command>()
{
}