using Core;

namespace Messages;

public record Time_Message(double Delta) : Message
{
    protected override void Start()
    {
    }
    protected override void End()
    {
    }
}
