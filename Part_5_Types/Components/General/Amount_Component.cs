using Core;

namespace Components_Namespace;

public record Amount_Component : Component
{
    public int Amount { get; set; }

    public Amount_Component(int amount)
    {
        Amount = amount;
    }
}

public static class Amount_Extensions
{
    public static Amount_Component Amount(this Components components)
    {
        return components.Get<Amount_Component>();
    }
}