using Core;

namespace Components_Namespace;

public record Shield_Component : Component
{
    public int Value { get; set; }
    public int Max { get; }

    public Shield_Component(int amount)
    {
        Value = amount;
        Max = amount;
    }
}

public static class Shield_Extensions
{
    public static Shield_Component Shield(this Components components)
    {
        return components.Get<Shield_Component>();
    }
}