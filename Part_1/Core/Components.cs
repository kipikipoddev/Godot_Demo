using System;
using System.Collections.Generic;
using System.Linq;

namespace Core;

public record Components : Component
{
    private readonly Dictionary<Type, List<Component>> components = new();

    public Components(params Component[] components)
    {
        Add_Range(components);
    }

    public Components Set(Component component)
    {
        component.Parent = this;
        foreach (var type in Get_Types(component.GetType()))
            components[type] = new() { component };
        return this;
    }

    public Components Add(Component component)
    {
        component.Parent = this;
        foreach (var type in Get_Types(component.GetType()))
        {
            if (!components.ContainsKey(type))
                components[type] = new();
            components[type].Add(component);
        }
        return this;
    }

    public Components Add_Range(IEnumerable<Component> components)
    {
        if (components != null)
            foreach (var component in components)
                Add(component);
        return this;
    }

    public T Get<T>()
        where T : Component
    {
        return Has<T>()
            ? (T)components[typeof(T)].FirstOrDefault()
            : default;
    }

    public IEnumerable<T> Get_All<T>()
        where T : Component
    {
        return components[typeof(T)].Select(c => (T)c);
    }

    public IEnumerable<T> Get_Components<T>()
        where T : Component
    {
        return Get_All<Components>()
            .Where(c => c.Has<T>())
            .SelectMany(c => c.Get_All<T>());
    }

    public void Remove<T>()
    {
        if (Has<T>())
            components.Remove(typeof(T));
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