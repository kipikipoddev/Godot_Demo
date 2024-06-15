using System;
using System.Collections.Generic;

namespace Core;

public record Components : Component
{
    private readonly Dictionary<Type, Component> components = new();

    public Components Set(Component component)
    {
        component.Parent = this;
        components[component.GetType()] = component;
        return this;
    }

    public T Get<T>()
        where T : Component
    {
        return components.ContainsKey(typeof(T))
            ? (T)components[typeof(T)]
            : default;
    }
}