using System;
using System.Collections.Generic;
using Core;

namespace Singletons;

public static class Mediator
{
    private static readonly Dictionary<Type, List<Action<object>>> listeners = new();
    private static readonly Dictionary<Type, Func<object, object>> handlers = new();

    public static void Call(Message message)
    {
        var types = Get_Types(message.GetType());
        foreach (var type in types)
            if (listeners.ContainsKey(type))
                listeners[type].ForEach(l => l(message));
    }

    public static V Call<V>(Request<V> request)
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

    private static IEnumerable<Type> Get_Types(Type type)
    {
        yield return type;
        if (type.BaseType != typeof(object))
            foreach (var base_type in Get_Types(type.BaseType))
                yield return base_type;
    }
}