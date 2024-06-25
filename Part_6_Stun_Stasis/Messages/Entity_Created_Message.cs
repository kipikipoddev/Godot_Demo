using Core;
using Interfaces;

namespace Messages;

public record Entity_Created_Message(IEntity_Model Entity) : Message
{
}
