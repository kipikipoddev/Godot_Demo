using Core;
using Interfaces;
using Models;

namespace Commands;

public record Shield_Command(Shield_Model Model, IHp_Model Target)
    : Message<Shield_Command>()
{
}