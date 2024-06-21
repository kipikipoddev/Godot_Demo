using Core;
using Interfaces;

namespace Messages;

public record Get_Target_Request(IAction_Model Action)
    : Request<IEntity_Model>
{
}