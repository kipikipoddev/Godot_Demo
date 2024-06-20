using Messages;

namespace Core;

public abstract record Command : Message
{
    public Command(bool invoke = true)
        : base(invoke)
    {
    }

    protected override void End()
    {
        if (Indentation == 1)
            new Update_Message();
        base.End();
    }
}