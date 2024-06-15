using System;
using System.Collections.Generic;

namespace Core;

public static class Mediator
{
    private static readonly Dictionary<Type, List<Action<object>>> listeners = new();
    private static readonly Dictionary<Type, Func<object, object>> handlers = new();

    public static void Send(Message message)
    {
        var type = message.GetType();
        if (listeners.ContainsKey(type))
            listeners[type].ForEach(l => l(message));
    }

    public static V Send<V>(Request<V> request)
    {
        return (V)handlers[request.GetType()](request);
    }

    public static void Add_Listener<T>(Action<T> listener)
        where T : Message
    {
        if (!listeners.ContainsKey(typeof(T)))
            listeners[typeof(T)] = new();
        listeners[typeof(T)].Add(o => listener((T)o));
    }

    public static void Set_Handler<T, V>(Func<T, V> handler)
        where T : Request<V>
    {
        handlers[typeof(T)] = o => handler((T)o);
    }
}