using System;
using System.Collections.Generic;

namespace Singletons;

public static class Mediator
{
    private static readonly Dictionary<Type, List<Action<object>>> listeners = new();

    public static void Call(Message message)
    {
        var types = Get_Types(message.GetType());
        foreach (var type in types)
            if (listeners.ContainsKey(type))
                listeners[type].ForEach(l => l(message));
    }

    public static void Add_Listener<T>(Action<T> listener)
        where T : Message
    {
        if (!listeners.ContainsKey(typeof(T)))
            listeners[typeof(T)] = new();
        listeners[typeof(T)].Add(o => listener((T)o));
    }

    private static IEnumerable<Type> Get_Types(Type type)
    {
        yield return type;
        if (type.BaseType != typeof(object))
            foreach (var base_type in Get_Types(type.BaseType))
                yield return base_type;
    }
}