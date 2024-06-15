using Core;

namespace Components_Namespace;

public record Armor_Component(int Armor) : Component
{
}

public static class Components_Armor_Extension
{
    public static int Armor(this Components components)
    {
        return components.Get_Or_Defualt<Armor_Component>()?.Armor ?? 0;
    }
}

