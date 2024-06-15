using Core;

namespace Components_Namespace;

public record Name_Component(string Name) : Component
{
}

public static class Components_Name_Extension
{
    public static string Name(this Components components)
    {
        return components.Get<Name_Component>().Name;
    }
}