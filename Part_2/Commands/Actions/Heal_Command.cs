using Components_Namespace;
using Core;
using Interfaces;
using Models;

namespace Commands;

public record Heal_Command(Heal_Action_Model Heal, IHp_Model Target) : Command
{
}