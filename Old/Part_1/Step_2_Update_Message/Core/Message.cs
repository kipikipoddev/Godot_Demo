using System;
using System.Collections.Generic;

namespace Core;

public abstract record Message<TMessage>
    where TMessage : class
{
    private static readonly List<Action<TMessage>> handlers = new();

    public Message()
    {
        var e = this as TMessage;
        foreach (var handler in handlers.ToArray())
            handler(e);
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