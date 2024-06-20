using Core;

namespace Messages;

public record Entity_Created_Message(Components Entity) : Message
{
}
