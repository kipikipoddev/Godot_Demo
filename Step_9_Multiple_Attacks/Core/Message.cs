using System;
using System.Collections.Generic;

namespace Core;

public abstract record Message<TMessage> : Base
    where TMessage : class
{
    private static readonly List<Action<TMessage>> handlers = new();

    public Message()
    {
        Started();
        var e = this as TMessage;
        foreach (var listener in handlers.ToArray())
            listener(e);
        Ended();
    }

    public static void Handle(Action<TMessage> handler)
    {
        if (!handlers.Contains(handler))
            handlers.Add(handler);
    }

    public static void Unhandle(Action<TMessage> handler)
    {
        if (handlers.Contains(handler))
            handlers.Remove(handler);
    }
}