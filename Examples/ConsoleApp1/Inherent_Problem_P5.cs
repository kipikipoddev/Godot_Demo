

namespace Inherent_Problem_P5;

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

    public bool Contains<T>()
    {
        return components.ContainsKey(typeof(T));
    }
}

public static class Component_Extensions
{
    public static void A(this Components components)
    {
        components.Get<Class_A>().A();
    }

    public static void B(this Components components)
    {
        if (components.Contains<Class_B>())
            components.Get<Class_B>().B();
    }
}

public class Runner
{
    public void Method(Components components)
    {
        components.A();
        components.B();
    }
}