using Core;

namespace Components_Namespace;

public record Amount_Component(int Amount) : Component
{
}

public static class Amount_Extensions
{
    public static int Amount(this Components components)
    {
        return components.Get<Amount_Component>().Amount;
    }
}