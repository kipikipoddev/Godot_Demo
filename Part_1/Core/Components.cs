using System;
using System.Collections.Generic;
using System.Linq;

namespace Core;

public record Components : Component
{
    private readonly Dictionary<Type, List<Component>> components = new();

    public Components(IEnumerable<Component> components = null)
    {
        if (components != null)
            foreach (var component in components)
                Add(component);
    }

    public Components Add(Component comp)
    {
        comp.Parent = this;
        var type = comp.GetType();
        if (!components.ContainsKey(type))
            components[type] = new();
        components[type].Add(comp);
        return this;
    }

    public Components Set(Component comp)
    {
        comp.Parent = this;
        components[comp.GetType()] = new() { comp };
        return this;
    }

    public Components Add_Range(IEnumerable<Component> comps)
    {
        foreach (var comp in comps)
            Add(comp);
        return this;
    }

    public Components Remove(Component comp)
    {
        if (components.ContainsKey(comp.GetType()))
        {
            var comps = components[comp.GetType()];
            comps.Remove(comp);
            comp.Parent = null;
        }
        return this;
    }

    public Components Remove<T>()
        where T : Component
    {
        var comp = Get_Or_Defualt<T>();
        if (comp != null)
        {
            comp.Parent = null;
            components.Remove(typeof(T));
        }
        return this;
    }

    public bool Has<T>() => Has(typeof(T));

    public bool Has(Type type) => components.ContainsKey(type) && components[type].Any();


    public T Get<T>()
        where T : Component
    {
        return (T)components[typeof(T)].First();
    }

    public IEnumerable<T> Get_All<T>()
        where T : Component
    {
        return components[typeof(T)].Select(c => (T)c);
    }

    public T Get_Or_Defualt<T>()
        where T : Component
    {
        return components.ContainsKey(typeof(T))
            ? (T)components[typeof(T)].FirstOrDefault()
            : default;
    }
}