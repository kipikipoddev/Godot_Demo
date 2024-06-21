using System.Collections.Generic;
using Core;
using Resources;

namespace Components_Namespace;

public record Armor_Component(int Amount, Type_Resource Type) : Amount_Component(Amount, Type)
{
}

public static class Armor_Extensions
{
    public static Armor_Component Armor(this Components components)
    {
        return components.Get<Armor_Component>();
    }

    public static IEnumerable<Armor_Component> Get_Armors(this Components components)
    {
        return components.Get_Has<Armor_Component>();
    }
}