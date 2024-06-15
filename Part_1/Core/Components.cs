using System.Collections.Generic;
using System.Linq;

namespace Core;

public record Components
{
    private readonly Dictionary<string, List<object>> components = new();

    public Components Parent { get; set; }

    public Components Add(string key, object component)
    {
        if (!components.ContainsKey(key))
            components[key] = new();
        components[key].Add(component);
        return this;
    }

    public Components Set(string key, object component)
    {
        components[key] = new() { component };
        return this;
    }

    public Components Add_Range(string key, IEnumerable<object> components)
    {
        foreach (var component in components)
            Add(key, component);
        return this;
    }

    public Components Clear(string key)
    {
        if (components.ContainsKey(key))
            components.Remove(key);
        return this;
    }

    public bool Has(string key) => components.ContainsKey(key) && components[key].Any();


    public T Get<T>(string key)
    {
        return components.ContainsKey(key)
            ? (T)components[key].FirstOrDefault()
            : default;
    }

    public IEnumerable<T> Get_All<T>(string key)
    {
        return components[key].Select(c => (T)c);
    }
}