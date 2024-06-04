using Core;
using Models;

namespace Commands;

public record Attack_Command(Entity_Model Model, Entity_Model Enemy)
    : Message<Attack_Command>()
{
}
