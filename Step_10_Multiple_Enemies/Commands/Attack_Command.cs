using Core;
using Models;

namespace Commands;

public record Attack_Command(Attack_Model Model, Entity_Model Target)
    : Message<Attack_Command>()
{
}
