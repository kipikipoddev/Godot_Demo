using System;
using System.Collections.Generic;

namespace Core;

public static class Mediator
{
    private static readonly Dictionary<Type, List<Action<object>>> message_listeners = new();
    private static readonly Dictionary<Type, List<Func<object, object>>> request_listeners = new();

    public static void Send(Message message)
    {
        var type = message.GetType();
        if (message_listeners.ContainsKey(type))
            message_listeners[type].ForEach(l => l(message));
    }

    public static V Send<V>(Request<V> request)
    {
        var type = request.GetType();
        if (request_listeners.ContainsKey(type))
        {
            foreach (var listener in request_listeners[type])
            {
                var result = listener(request);
                if (result != default)
                    return (V)result;
            }
        }
        return default;
    }

    public static void Add_Listener<T>(Action<T> listener)
        where T : Message
    {
        if (!message_listeners.ContainsKey(typeof(T)))
            message_listeners[typeof(T)] = new();
        message_listeners[typeof(T)].Add(o => listener((T)o));
    }

    public static void Add_Listener<T, V>(Func<T, V> listener)
        where T : Request<V>
    {
        if (!request_listeners.ContainsKey(typeof(T)))
            request_listeners[typeof(T)] = new();
        request_listeners[typeof(T)].Add(o => listener((T)o));
    }
}