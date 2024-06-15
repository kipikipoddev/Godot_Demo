using Messages;

namespace Core;

public abstract record Command : Message
{
    protected override void End()
    {
        if (Indentation == 1)
            new Update_Message();
        base.End();
    }
}