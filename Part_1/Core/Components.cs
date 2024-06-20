using System;
using System.Collections.Generic;
using System.Linq;

namespace Core;

public record Components : Component
{
    private readonly Dictionary<Type, Component> components = new();

    public Components Set(Component component)
    {
        component.Parent = this;
        foreach (var type in Get_Types(component.GetType()))
            components[type] = component;
        return this;
    }

    public T Get<T>()
        where T : Component
    {
        return Has<T>()
            ? (T)components[typeof(T)]
            : default;
    }

    public bool Has<T>() => components.ContainsKey(typeof(T));

    private IEnumerable<Type> Get_Types(Type type)
    {
        yield return type;
        if (type.BaseType != typeof(object))
            foreach (var t in Get_Types(type.BaseType))
                yield return t;
    }
}