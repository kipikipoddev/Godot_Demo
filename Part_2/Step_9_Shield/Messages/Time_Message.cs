using Core;

namespace Messages;

public record Time_Message(double Delta) : Message<Time_Message>
{
    protected override void Started()
    {
    }
    protected override void Ended()
    {
    }
}
