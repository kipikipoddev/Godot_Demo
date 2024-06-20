using System;
using System.Collections.Generic;

namespace Core;

public static class Mediator
{
    private static readonly Dictionary<Type, List<Action<object>>> message_listeners = new();
    private static readonly Dictionary<Type, Func<object, object>> requests_handler = new();

    public static void Send(Message message)
    {
        var type = message.GetType();
        if (message_listeners.ContainsKey(type))
            message_listeners[type].ForEach(l => l(message));
    }

    public static V Send<V>(Request<V> request)
    {
        var listener = requests_handler[request.GetType()];
        return (V)listener(request);
    }

    public static void Add_Listener<T>(Action<T> listener)
        where T : Message
    {
        if (!message_listeners.ContainsKey(typeof(T)))
            message_listeners[typeof(T)] = new();
        message_listeners[typeof(T)].Add(o => listener((T)o));
    }

    public static void Add_Handler<T, V>(Func<T, V> listener)
        where T : Request<V>
    {
        requests_handler[typeof(T)] = o => listener((T)o);
    }
}