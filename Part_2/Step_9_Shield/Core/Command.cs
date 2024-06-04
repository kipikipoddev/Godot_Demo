using System;
using Messages;

namespace Core;

public abstract record Command<TCommand> : Base
    where TCommand : class
{
    public static Action<TCommand> Handler;

    public Command(bool update_message = true)
    {
        Started();
        Handler(this as TCommand);
        if (Indentation == 1 & update_message)
            new Update_Message();
        Ended();
    }
}