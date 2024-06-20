using System;
using System.Collections.Generic;
using System.Linq;

namespace Core;

public record Components : Component
{
    private readonly List<Components> components = new();
    private readonly Dictionary<Type, Component> type_to_component = new();

    public Components Set(Component component)
    {
        component.Parent = this;
        foreach (var type in Get_Types(component.GetType()))
            type_to_component[type] = component;
        return this;
    }

    public Components Add(Components components)
    {
        components.Parent = this;
        this.components.Add(components);
        return this;
    }

    public Components Add_Range(IEnumerable<Components> components)
    {
        foreach (var component in components)
            Add(component);
        return this;
    }

    public T Get<T>()
        where T : Component
    {
        return Has<T>()
            ? (T)type_to_component[typeof(T)]
            : default;
    }

    public IEnumerable<T> Get_Has<T>()
        where T : Component
    {
        return components.Where(c => c.Has<T>())
            .Select(c => c.Get<T>());
    }

    public void Remove<T>()
    {
        type_to_component.Remove(typeof(T));
    }

    public bool Has<T>() => type_to_component.ContainsKey(typeof(T));

    private IEnumerable<Type> Get_Types(Type type)
    {
        yield return type;
        if (type.BaseType != typeof(object))
            foreach (var t in Get_Types(type.BaseType))
                yield return t;
    }
}