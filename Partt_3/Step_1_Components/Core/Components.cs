using System;
using System.Collections.Generic;
using System.Linq;
using Components_Namespace;

namespace Core;

public class Components : Component
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
        comp.Owner = this;
        var types = Get_types(comp.GetType());
        foreach (var type in types)
        {
            if (!components.ContainsKey(type))
                components[type] = new();
            components[type].Add(comp);
        }
        return this;
    }

    public Components Set(Component comp)
    {
        comp.Owner = this;
        var types = Get_types(comp.GetType());
        foreach (var type in types)
            components[type] = new() { comp };
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
            comp.Owner = null;
        }
        return this;
    }

    public Components Remove<T>()
        where T : Component
    {
        var comp = Get_Or_Defualt<T>();
        if (comp != null)
        {
            comp.Owner = null;
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
            : null;
    }

    private IEnumerable<Type> Get_types(Type type)
    {
        var types = new List<Type>() { type };
        if (type.BaseType != null)
        {
            types.Add(type.BaseType);
            types.AddRange(Get_types(type.BaseType));
        }
        return types;
    }
}