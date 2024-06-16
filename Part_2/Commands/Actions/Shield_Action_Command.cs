using Components_Namespace;
using Core;
using Interfaces;
using Models;

namespace Commands;

public record Shield_Action_Command(Shield_Action_Model Action, IHp_Model Target) : Command
{
}