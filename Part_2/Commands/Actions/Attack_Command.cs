using Core;
using Interfaces;
using Models;

namespace Commands;

public record Attack_Command(Attack_Action_Model Attack, IHp_Model Target) : Command
{
}