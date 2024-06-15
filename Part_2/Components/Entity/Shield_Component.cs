using Core;

namespace Components_Namespace;

public record Shield_Component : Component
{
    public Ranged_Value<int> Shield { get; set; }

    public Shield_Component(int amount)
    {
        Shield = new(amount, 0, amount);
    }
}

public static class Shield_Extensions
{
    public static Ranged_Value<int> Shield(this Components components)
    {
        return components.Get<Shield_Component>()?.Shield;
    }
}