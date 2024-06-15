using Core;

namespace Components_Namespace;

public record Armor_Component(int Armor) : Component
{
}

public static class Armor_Extensions
{
    public static int Armor(this Components components)
    {
        return components.Get<Armor_Component>().Armor;
    }
}