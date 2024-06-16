

namespace Inherent_Problem_P4;

public class Class_A
{
    public void A() { }
}

public class Class_B
{
    public void B() { }
}

public class Components
{
    private Dictionary<Type, object> components = new();

    public void Set(object component)
    {
        components[component.GetType()] = component;
    }

    public T Get<T>()
    {
        return (T)components[typeof(T)];
    }

    public bool Has<T>()
    {
        return components.ContainsKey(typeof(T));
    }
}

public class Runner
{
    public void Method(Components components)
    {
        components.Get<Class_A>().A();
        if (components.Has<Class_B>())
            components.Get<Class_B>().B();
    }
}