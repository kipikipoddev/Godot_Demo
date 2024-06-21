using Core;
using Resources;

namespace Components_Namespace;

public record Amount_Component(int Amount, Type_Resource Type) : Component
{
}

public static class Amount_Extensions
{
    public static Amount_Component Amount(this Components components)
    {
        return components.Get<Amount_Component>();
    }
}